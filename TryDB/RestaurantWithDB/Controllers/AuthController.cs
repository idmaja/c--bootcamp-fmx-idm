using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IValidator<RegisterRequest> _registerValidator;
    private readonly IValidator<LoginRequest> _loginValidator;

    public AuthController(
        IAuthService authService, 
        IValidator<RegisterRequest> registerValidator,
        IValidator<LoginRequest> loginValidator
    ){
        _authService = authService;
        _registerValidator = registerValidator;
        _loginValidator = loginValidator;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<AuthResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<ValidationResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> Regsiter([FromBody] RegisterRequest request)
    {
        try
        {
            var result = await _authService.RegisterAsync(request);
            if (!result.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = result.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<AuthResponse>
            {
                Status = true,
                Message = "Register successful!",
                Data = result.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to register: {ex.Message}",
                Data = null
            });
        }
    }    
    
    [HttpPost("login")]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<AuthResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<ValidationResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        try
        {
            var result = await _authService.LoginAsync(request);
            if (!result.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = result.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<AuthResponse>
            {
                Status = true,
                Message = "Login successful!",
                Data = result.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to login: {ex.Message}",
                Data = null
            });
        }
    }
}