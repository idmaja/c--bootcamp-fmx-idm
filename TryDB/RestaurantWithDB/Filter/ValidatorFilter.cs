using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

public class ValidatorFilter : IAsyncActionFilter
{
    private readonly Serilog.ILogger _logger;

    public ValidatorFilter()
    {
        _logger = Log.ForContext<ValidatorFilter>();
    }

    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, 
        ActionExecutionDelegate next
    ){
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(error => error.Value!.Errors.Count > 0)
                .SelectMany(error => error.Value!.Errors)
                .Select(error => error.ErrorMessage)
                .ToList();

            var userIp = context.HttpContext.Connection.RemoteIpAddress!.MapToIPv4().ToString();

            _logger.Error("[BADREQUEST] - User with IP: {userIp}, errors: {errors}", userIp, errors);

            var errorResult = new ValidationResponse
            {
                Time = DateTime.UtcNow,
                Errors = errors
            };

            var response = new GlobalResponse<object>
            {
                Status = false,
                Message = "Validation Errors",
                Data = errorResult
            };

            context.Result = new BadRequestObjectResult(response);
            return;
        }
        
        await next();
    }
}