using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/account/account")]
[CustomRoleAuthorize("Admin", "SuperAdmin")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly Serilog.ILogger _logger;

    public AccountController(IAccountService accountService){
        _accountService = accountService;
        
        _logger = Log.ForContext<AccountController>();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All accounts"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<IEnumerable<AccountResponse>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> GetAccounts()
    {
        try
        {
            var accounts = await _accountService.GetAllAccountsAsync();
            if (!accounts.Success)
            {     
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = accounts.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "All Account(s) retrieved successfully",
                Data = accounts.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get all account(s): {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve all account(s)",
                Data = null
            });
        }
    }

    [HttpGet("{accountId}")]
    [SwaggerOperation(
        Summary = "Get account by ID"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<AccountResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> GetAccountById(string accountId)
    {
        try
        {
            var account = await _accountService.GetAccountByIdAsync(accountId);
            if (!account.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = account.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<AccountResponse>
            {
                Status = true,
                Message = "Get Account by ID retrieved successfully",
                Data = account.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get Account by ID: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve account",
                Data = null
            });
        }
    }

    [HttpPost]
    [CustomRoleAuthorize("SuperAdmin")]
    [SwaggerOperation(
        Summary = "Create an account",
        Description = "",
        OperationId = "CreateAccount"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<AccountResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> AddAccount([FromBody] CreateAccountRequest request)
    {
        try
        {
            var account = await _accountService.CreateAccountAsync(request);
            if (!account.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = account.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<AccountResponse>
            {
                Status = true,
                Message = "Successfully added an Account",
                Data = account.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to create account: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to create account",
                Data = null
            });
        }
    }

    [HttpPut("{accountId}")]
    [CustomRoleAuthorize("SuperAdmin")]
    [SwaggerOperation(
        Summary = "Update an account",
        Description = "",
        OperationId = "UpdateAccount"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<AccountResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> UpdateAccount(string accountId, [FromBody] UpdateAccountRequest request)
    {
        try
        {
            var account = await _accountService.UpdateAccountAsync(accountId, request);
            if (!account.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = account.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<AccountResponse>
            {
                Status = true,
                Message = "Successfully updated an Account",
                Data = account.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to update account: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to update account",
                Data = null
            });
        }
    }
}