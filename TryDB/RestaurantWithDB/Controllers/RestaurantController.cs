using Microsoft.AspNetCore.Mvc;
using Serilog;
using Swashbuckle.AspNetCore.Annotations;

[ApiController]
[Route("api/v1/restaurant")]
public class RestaurantController : ControllerBase
{
    private readonly IRestaurantService _restaurantService;
    private readonly Serilog.ILogger _logger;

    public RestaurantController(IRestaurantService restaurantService){
        _restaurantService = restaurantService;
        
        _logger = Log.ForContext<RestaurantController>();
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get All restaurants"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<IEnumerable<RestaurantResponse>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> GetRestaurants()
    {
        try
        {
            var restaurants = await _restaurantService.GetAllRestaurantsAsync();
            if (!restaurants.Success)
            {     
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = restaurants.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = "All Restaurant(s) retrieved successfully",
                Data = restaurants.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get all restaurant(s): {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve all restaurant(s)",
                Data = null
            });
        }
    }

    [HttpGet("{restaurantId}")]
    [SwaggerOperation(
        Summary = "Get restaurant by ID"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<RestaurantResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> GetRestaurantById(string restaurantId)
    {
        try
        {
            var restaurant = await _restaurantService.GetRestaurantByIdAsync(restaurantId);
            if (!restaurant.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = restaurant.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<RestaurantResponse>
            {
                Status = true,
                Message = "Get Restaurant by ID retrieved successfully",
                Data = restaurant.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to get Restaurant by ID: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to retrieve restaurant",
                Data = null
            });
        }
    }

    [HttpPost]
    [CustomRoleAuthorize("SuperAdmin")]
    [SwaggerOperation(
        Summary = "Create a restaurant",
        Description = "",
        OperationId = "CreateRestaurant"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<RestaurantResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> AddRestaurant([FromBody] CreateRestaurantRequest request)
    {
        try
        {
            var restaurant = await _restaurantService.CreateRestaurantAsync(request);
            if (!restaurant.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = restaurant.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<RestaurantResponse>
            {
                Status = true,
                Message = "Successfully added a Restaurant",
                Data = restaurant.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to create restaurant: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to create restaurant",
                Data = null
            });
        }
    }

    [HttpPut("{restaurantId}")]
    [CustomRoleAuthorize("SuperAdmin")]
    [SwaggerOperation(
        Summary = "Update a restaurant",
        Description = "",
        OperationId = "UpdateRestaurant"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<RestaurantResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> UpdateRestaurant(string restaurantId, [FromBody] UpdateRestaurantRequest request)
    {
        try
        {
            var restaurant = await _restaurantService.UpdateRestaurantAsync(restaurantId, request);
            if (!restaurant.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = restaurant.Error,
                    Data = null
                });
            }

            return Ok(new GlobalResponse<RestaurantResponse>
            {
                Status = true,
                Message = "Successfully updated a Restaurant",
                Data = restaurant.Value
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to update restaurant: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to update restaurant",
                Data = null
            });
        }
    }

    [HttpDelete("{restaurantId}")]
    [CustomRoleAuthorize("SuperAdmin")]
    [SwaggerOperation(
        Summary = "Delete a restaurant",
        Description = "",
        OperationId = "DeleteRestaurant"
    )]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(GlobalResponse<object>))]
    [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(GlobalResponse<object>))]
    public async Task<IActionResult> DeleteRestaurant(string restaurantId)
    {
        try
        {
            var restaurant = await _restaurantService.DeleteRestaurantAsync(restaurantId);
            if (!restaurant.Success)
            {
                return BadRequest(new GlobalResponse<object>
                {
                    Status = false,
                    Message = restaurant.Error,
                    Data = null
                });
            }
            return Ok(new GlobalResponse<object>
            {
                Status = true,
                Message = $"Successfully deleted '{restaurant.Value.RestaurantName}' !",
                Data = null
            });
        }
        catch (Exception ex)
        {
            _logger.Error("[CONTROLLER] Failed to delete restaurant: {message}", ex.Message);
            return BadRequest(new GlobalResponse<object>
            {
                Status = false,
                Message = $"Failed to delete restaurant",
                Data = null
            });
        }
    }
}