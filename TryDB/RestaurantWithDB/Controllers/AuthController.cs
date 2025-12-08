using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly Serilog.ILogger _logger;


    public AuthController(
        IAuthService authService,
        Serilog.ILogger logger
    ){
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("register")]
    [SwaggerOperation(
        Summary = "Register for user"
    )]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<AuthResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<ValidationResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
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
            _logger.Error("[CONTROLLER] Failed to register: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to register!",
                Data = null
            });
        }
    }    
    
    [HttpPost("login")]
    [SwaggerOperation(
        Summary = "Login for user"
    )]
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
            _logger.Error("[CONTROLLER] Failed to login: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to login!",
                Data = null
            });
        }
    }
}