using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly Serilog.ILogger _logger;

    public AccountService(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager, 
        IMapper mapper)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _mapper = mapper;

        _logger = Log.ForContext<AccountService>();
    }

    public async Task<Result<IEnumerable<AccountResponse>>> GetAllAccountsAsync()
    {
        _logger.Information("[SERVICE] Get all Account(s)");

        try
        {
            var accounts = await _userManager.Users.ToListAsync();
            if (accounts.Count() == 0)
            {
                _logger.Warning("[SERVICE] Account(s) is empty");
                return Result<IEnumerable<AccountResponse>>.Failed("Account(s) is empty!");
            }

            var accountResponse = new List<AccountResponse>();

            foreach (var account in accounts)
            {
                var response = _mapper.Map<AccountResponse>(account);
                response.Roles = await _userManager.GetRolesAsync(account);
                accountResponse.Add(response);
            }

            return Result<IEnumerable<AccountResponse>>.Ok(accountResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get all Account(s): {message}", ex.Message);
            return Result<IEnumerable<AccountResponse>>.Failed("Failed to get all Account(s)");
        }
    }

    public async Task<Result<AccountResponse>> GetAccountByIdAsync(string id)
    {
        _logger.Information("[SERVICE] Get Account by ID: {id}", id);

        try
        {
            var account = await _userManager.FindByIdAsync(id);
            if (account == null)
            {
                _logger.Warning("[SERVICE] Account not found");
                return Result<AccountResponse>.Failed("Account not found!");
            }

            var accountResult = _mapper.Map<AccountResponse>(account);
            accountResult.Roles = await _userManager.GetRolesAsync(account);

            return Result<AccountResponse>.Ok(accountResult);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get Account by ID: {message}", ex.Message);
            return Result<AccountResponse>.Failed("Failed to get Account");
        }
    }

    public async Task<Result<AccountResponse>> CreateAccountAsync(CreateAccountRequest request)
    {
        _logger.Information("[SERVICE] Create Account");

        try
        {
            var existingUser = await _userManager.FindByEmailAsync(request.EmailAddress!);
            if(existingUser != null)
            {
                return Result<AccountResponse>.Failed($"This user with email {request.EmailAddress} is exists!");
            }

            var newUser = _mapper.Map<IdentityUser>(request);
            
            newUser.Id = Guid.NewGuid().ToString().ToUpper();

            var createdUserResult = await _userManager.CreateAsync(newUser, request.Password!);
            if (!createdUserResult.Succeeded)
            {
                return Result<AccountResponse>.Failed(string.Join(", ", createdUserResult.Errors.Select(e => e.Description)));
            }

            var roleExists = await _roleManager.RoleExistsAsync(request.Role!);
            if (roleExists)
            {
                await _userManager.AddToRoleAsync(newUser, request.Role!);
            }

            var accountResult = _mapper.Map<AccountResponse>(newUser);
            accountResult.Roles = await _userManager.GetRolesAsync(newUser); 

            return Result<AccountResponse>.Ok(accountResult);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to create Account: {message}", ex.Message);
            return Result<AccountResponse>.Failed("Failed to create Account");
        }
    }

    public async Task<Result<AccountResponse>> UpdateAccountAsync(string id, UpdateAccountRequest request)
    {
        _logger.Information("[SERVICE] Create Account");

        try
        {
            var existingUser = await _userManager.FindByIdAsync(id);
            if(existingUser == null)
            {
                return Result<AccountResponse>.Failed($"This user with email {request.EmailAddress} not found!");
            }

            _mapper.Map(request, existingUser);

            var createdUserResult = await _userManager.UpdateAsync(existingUser);
            if (!createdUserResult.Succeeded)
            {
                return Result<AccountResponse>.Failed(string.Join(", ", createdUserResult.Errors.Select(e => e.Description)));
            }

            if (!string.IsNullOrEmpty(request.Role))
            {
                var roleExists = await _roleManager.RoleExistsAsync(request.Role);
                if (!roleExists)
                {
                    return Result<AccountResponse>.Failed($"Role '{request.Role}' does not exist.");
                }

                var currentRoles = await _userManager.GetRolesAsync(existingUser);

                var removeResult = await _userManager.RemoveFromRolesAsync(existingUser, currentRoles);
                if (!removeResult.Succeeded)
                {
                    return Result<AccountResponse>.Failed("Failed to remove old roles.");
                }

                var addResult = await _userManager.AddToRoleAsync(existingUser, request.Role);
                if (!addResult.Succeeded)
                {
                    return Result<AccountResponse>.Failed("Failed to add new role.");
                }
            }

            var accountResult = _mapper.Map<AccountResponse>(existingUser);
            
            accountResult.Roles = await _userManager.GetRolesAsync(existingUser);

            return Result<AccountResponse>.Ok(accountResult);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to create Account: {message}", ex.Message);
            return Result<AccountResponse>.Failed("Failed to create Account");
        }
    }
}