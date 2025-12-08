using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly Serilog.ILogger _logger;

    public AuthService( 
        UserManager<IdentityUser> userManager,  
        RoleManager<IdentityRole> roleManager,
        SignInManager<IdentityUser> signInManager,
        IConfiguration configuration,
        IMapper mapper
    ){
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _mapper = mapper;
        _logger = Log.ForContext<AuthService>();
    }

    public async Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, string role = "User")
    {
        _logger.Information("[SERVICE] Register");

        try
        {
            var existingUser = await _userManager.FindByEmailAsync(request.Email!);
            if(existingUser != null)
            {
                _logger.Warning("[SERVICE] User with email {request.Email} is exists!", request.Email);
                return Result<AuthResponse>.Failed($"User with email {request.Email} is exists!");
            }

            var newUser = _mapper.Map<IdentityUser>(request);
            newUser.Id = Guid.NewGuid().ToString().ToUpper();

            var createdUserResult = await _userManager.CreateAsync(newUser, request.Password!);
            if (!createdUserResult.Succeeded)
            {
                var errors = string.Join(", ", createdUserResult.Errors.Select(e => e.Description));
                _logger.Warning(
                    "[AUTH-SERVICE] Failed to create user: {newUser.Email}, reason: {reason}", 
                    newUser.Email, errors
                );
                return Result<AuthResponse>.Failed(errors);
            }

            var roleExists = await _roleManager.RoleExistsAsync(role);
            if (roleExists)
            {
                await _userManager.AddToRoleAsync(newUser, role);
            }

            var userResult = _mapper.Map<AccountResponse>(newUser);

            return Result<AuthResponse>.Ok(new AuthResponse { 
                User = userResult,
                Token = null
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to register: {message}", ex.Message);
            return Result<AuthResponse>.Failed("Failed to register.");
        }

    }

    public async Task<Result<AuthResponse>> LoginAsync(LoginRequest request)
    {
        _logger.Information("[SERVICE] Login");

        try
        {
            var loginResult = await _signInManager.PasswordSignInAsync(
                request.Username!,
                request.Password!,
                isPersistent: false,
                lockoutOnFailure: false
            );

            if (!loginResult.Succeeded)
            {
                _logger.Warning("[SERVICE] Invalid username or password!");
                return Result<AuthResponse>.Failed("Invalid username or password!");
            }

            var user = await _userManager.FindByNameAsync(request.Username!);
            var token = await GenerateJwtToken(user!);

            var userResult = _mapper.Map<AccountResponse>(user);

            return Result<AuthResponse>.Ok(new AuthResponse { 
                User = userResult,
                Token = token
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to login: {message}", ex.Message);
            return Result<AuthResponse>.Failed("Failed to login.");
        }
    }

    private async Task<string> GenerateJwtToken(IdentityUser user)
    {
        var jwtKey = _configuration["Jwt:Key"];
        var jwtIssuer = _configuration["Jwt:Issuer"];
        var jwtAudience = _configuration["Jwt:Audience"];
        var jwtExpireHours = _configuration.GetValue<int>("Jwt:ExpireHours", 2);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty)
        };

        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: jwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(jwtExpireHours),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}