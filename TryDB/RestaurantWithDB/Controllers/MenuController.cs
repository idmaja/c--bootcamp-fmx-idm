using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/restaurant/menu")]
// [Authorize(Roles = "Admin,SuperAdmin")] // default Authorization
[CustomRoleAuthorize("Admin", "SuperAdmin")] // Custom Authorization returns
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    private readonly Serilog.ILogger _logger;

    public MenuController(
        IMenuService menuService
    ){
        _menuService = menuService;
        _logger = Log.ForContext<MenuController>();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All menus"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<IEnumerable<MenuResponse>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> GetMenus()
    {
        try
        {
            var menus = await _menuService.GetAllMenusAsync();
            if (!menus.Success)
            {     
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = menus.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "All Menu(s) retrieved successfully",
                Data = menus.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get all menu(s): {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve all menu(s)",
                Data = null
            });
        }
    }

    [HttpGet("{menuId}")]
    [SwaggerOperation(
        Summary = "Get menu by ID"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<MenuResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> GetMenuById(string menuId)
    {
        try
        {
            var menu = await _menuService.GetMenuByIdAsync(menuId);
            if (!menu.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = menu.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<MenuResponse>
            {
                Status = true,
                Message = "Get Menu by ID retrieved successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get Menu by ID: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve menu",
                Data = null
            });
        }
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a menu",
        Description = "",
        OperationId = "CreateMenu"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<MenuResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> AddMenu([FromBody] CreateMenuRequest request)
    {
        try
        {
            var menu = await _menuService.CreateMenuAsync(request);
            if (!menu.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = menu.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<MenuResponse>
            {
                Status = true,
                Message = "Added a Menu successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to create menu: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to create menu",
                Data = null
            });
        }
    }

    [HttpPut("{menuId}")]
    [SwaggerOperation(
        Summary = "Update a menu",
        Description = "",
        OperationId = "UpdateMenu"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<MenuResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> UpdateMenu(string menuId, [FromBody] UpdateMenuRequest request)
    {
        try
        {
            var menu = await _menuService.UpdateMenuAsync(menuId, request);
            if (!menu.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = menu.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<MenuResponse>
            {
                Status = true,
                Message = "Updated a Menu successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to update menu: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to update menu",
                Data = null
            });
        }
    }

    [HttpDelete("{menuId}")]
    [SwaggerOperation(
        Summary = "Delete a menu",
        Description = "",
        OperationId = "DeleteMenu"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> DeleteMenu(string menuId)
    {
        try
        {
            var menu = await _menuService.DeleteMenuAsync(menuId);
            if (!menu.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = menu.Error,
                    Data = null
                });
            }
            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = $"Deleted '{menu.Value.Name}' successfully",
                Data = null
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to delete menu: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to delete menu",
                Data = null
            });
        }
    }

    [HttpGet("total-value-stock")]
    [Authorize(Roles = "Admin,SuperAdmin,User")]
    [SwaggerOperation(
        Summary = "Get total value by stock",
        Description = "",
        OperationId = "TotalValueStock"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]

    public async Task<IActionResult> GetTotalStockValue()
    {
        try
        {
            var totalStockValue = await _menuService.GetTotalStockValueAsync();
            if (!totalStockValue.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = totalStockValue.Error,
                    Data = null
                });
            }
            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "Get total stock value successfully",
                Data = totalStockValue.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get total stock value: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to get total value by stock menu(s)",
                Data = null
            });
        }
    }
}