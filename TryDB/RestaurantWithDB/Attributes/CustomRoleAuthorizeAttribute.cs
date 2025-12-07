using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class CustomRoleAuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _roles;

    public CustomRoleAuthorizeAttribute(params string[] roles)
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity!.IsAuthenticated)
        {
            context.Result = new JsonResult(new GlobalResponse<object>
            {
                Status = false,
                Message = "[401] - Unauthorized. Please login first.",
                Data = null 
            })
            { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }

        if(_roles.Length > 0)
        {
            bool hasRole = false;
            foreach (var role in _roles)
            {
                if (user.IsInRole(role))
                {
                    hasRole = true;
                    break;
                }
            }

            if (!hasRole)
            {
                context.Result = new JsonResult(new GlobalResponse<object>
                {
                    Status = false,
                    Message = "[403] - Authorization has failed, the Role is not fit",
                    Data = null 
                })
                { StatusCode = StatusCodes.Status403Forbidden };
            }
        }
    }
}