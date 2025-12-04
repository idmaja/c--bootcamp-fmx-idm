using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/restaurant/menu")]
public class MenuController : ControllerBase
{
    private readonly IMenuService _menuService;
    private readonly Serilog.ILogger _logger;

    public MenuController(IMenuService menuService)
    {
        _menuService = menuService;
        _logger = Log.ForContext<MenuController>();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All menus"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<List<Menu>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]

    public async Task<IActionResult> GetMenus()
    {
        try
        {
            var menus = await _menuService.GetAllMenusAsync();
            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "Menus retrieved successfully",
                Data = menus.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve menus: {ex.Message}",
                Data = null
            });
        }
    }

    [HttpGet("{menuId}")]
    [SwaggerOperation(
        Summary = "Get menu by ID"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<Menu>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]

    public async Task<IActionResult> GetMenuById(string menuId)
    {
        try
        {
            var menu = await _menuService.GetMenuByIdAsync(menuId);
            return Ok(new GlobalResponse<Menu>
            {
                Status = true,
                Message = "Get Menu by ID retrieved successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve menus: {ex.Message}",
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<Menu>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]

    public async Task<IActionResult> AddMenu([FromBody] MenuRequest request)
    {
        try
        {
            var menu = await _menuService.CreateMenuAsync(request);
            return Ok(new GlobalResponse<Menu>
            {
                Status = true,
                Message = "Added a Menu successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to create a menu {ex.Message}",
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<Menu>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]

    public async Task<IActionResult> UpdateMenu(string menuId, [FromBody] MenuRequest request)
    {
        try
        {
            var menu = await _menuService.UpdateMenuAsync(menuId, request);
            return Ok(new GlobalResponse<Menu>
            {
                Status = true,
                Message = "Updated a Menu successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to update a menu {ex.Message}",
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

    public async Task<IActionResult> DeleteMenu(string menuId)
    {
        try
        {
            var menu = await _menuService.DeleteMenuAsync(menuId);
            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "Deleted a Menu successfully",
                Data = null
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to delete a menu {ex.Message}",
                Data = null
            });
        }
    }

    [HttpGet("total-value-stock")]
    [SwaggerOperation(
        Summary = "Get total value by stock",
        Description = "",
        OperationId = "TotalValueStock"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]

    public async Task<IActionResult> GetTotalStockValue()
    {
        try
        {
            var menu = await _menuService.GetTotalStockValueAsync();
            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "Get total stock value successfully",
                Data = menu.Value
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to get total stock value: {ex.Message}",
                Data = null
            });
        }
    }

}