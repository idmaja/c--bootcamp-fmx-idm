using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/restaurant")]
public class MainController : ControllerBase
{
    private readonly IMainServiceRestaurant _mainRestaurantService;
    private readonly Serilog.ILogger _logger;

    public MainController(IMainServiceRestaurant mainRestaurantService)
    {
        _mainRestaurantService = mainRestaurantService;
        _logger = Log.ForContext<MainController>();
    }

    [HttpGet("restaurant-info")]
    [SwaggerOperation(
        Summary = "Get information about Restaurant",
        Description = "",
        OperationId = "RestaurantInfo"
    )]
    public IActionResult GetRestaurantInfo()
    {
        try
        {
            var restaurantInfo = _mainRestaurantService.GetRestaurantInfo();
            _logger?.Information($"[GETRESTAURANTINFO] - Restaurant info retrieved successfully");
            return Ok(new
            {
                Success = true,
                Message = "Restaurant info retrieved successfully",
                Data = new
                {
                    restaurantInfo
                }
            });
        }
        catch (Exception ex)
        {
            _logger?.Error($"[GETRESTAURANTINFO] - Error while retrieving restaurant info: {ex.Message}");
            return BadRequest(new
            {
                Success = false,
                Message = "Failed to retrieve restaurant info",
            });
        }
    }
}