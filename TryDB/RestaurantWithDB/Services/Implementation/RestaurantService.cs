using AutoMapper;
using Serilog;

public class RestaurantService : IRestaurantService
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly Serilog.ILogger _logger;
    private readonly IMapper _mapper;

    public RestaurantService(IRestaurantRepository restaurantRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _mapper = mapper;

        _logger = Log.ForContext<RestaurantService>();
    }

    public async Task<Result<IEnumerable<RestaurantResponse>>> GetAllRestaurantsAsync()
    {
        _logger.Information("[SERVICE] Get all Restaurant(s)");

        try
        {
            var restaurants = await _restaurantRepository.GetAllAsync();
            if (restaurants.Count() == 0)
            {
                _logger.Warning("[SERVICE] Restaurant(s) is empty");
                return Result<IEnumerable<RestaurantResponse>>.Failed("Restaurant(s) is empty!");
            }

            var restaurantsResponse = _mapper.Map<IEnumerable<RestaurantResponse>>(restaurants);

            return Result<IEnumerable<RestaurantResponse>>.Ok(restaurantsResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get all Restaurant(s): {message}", ex.Message);
            return Result<IEnumerable<RestaurantResponse>>.Failed("Failed to get all Restaurant(s)");
        }
    }

    public async Task<Result<RestaurantResponse>> GetRestaurantByIdAsync(string id)
    {
        _logger.Information("[SERVICE] Get a restaurant with Restaurant ID: {id}", id);

        try
        {
            if(!Guid.TryParse(id.ToString(), out Guid idRestaurant))
            {
                _logger.Error("[SERVICE] Invalid ID Restaurant: {id}", id);
                return Result<RestaurantResponse>.Failed("Invalid ID Restaurant");
            }

            var restaurant = await _restaurantRepository.GetByIdAsync(idRestaurant);
            if (restaurant == null)
            {
                _logger.Warning("[SERVICE] Restaurant not found");
                return Result<RestaurantResponse>.Failed("Restaurant not found");
            }

            var restaurantResponse = _mapper.Map<RestaurantResponse>(restaurant);

            return Result<RestaurantResponse>.Ok(restaurantResponse);   
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to get restaurant by ID: {message}", ex.Message);
            return Result<RestaurantResponse>.Failed("Failed to get restaurant");
        }
    }

    public async Task<Result<RestaurantResponse>> CreateRestaurantAsync(CreateRestaurantRequest request)
    {
        _logger.Information("[SERVICE] Create a restaurant");

        try
        {    
            var newRestaurant = _mapper.Map<Restaurant>(request);

            newRestaurant.IsDeleted = false;
            newRestaurant.CreatedAt = DateTime.UtcNow;
            newRestaurant.UpdatedAt = DateTime.UtcNow;

            var result = await _restaurantRepository.AddAsync(newRestaurant);

            var restaurantResponse = _mapper.Map<RestaurantResponse>(result);

            return Result<RestaurantResponse>.Ok(restaurantResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to create Restaurant: {message}", ex.Message);
            return Result<RestaurantResponse>.Failed("Failed to create restaurant");
        }
    }

    public async Task<Result<RestaurantResponse>> UpdateRestaurantAsync(string id, UpdateRestaurantRequest request)
    {
        _logger.Information("[SERVICE] Update a restaurant with id: {id}", id);

        try
        {    
            if(!Guid.TryParse(id.ToString(), out Guid idRestaurant))
            {
                return Result<RestaurantResponse>.Failed("Invalid ID Restaurant");
            }

            var existingRestaurant = await _restaurantRepository.GetByIdAsync(idRestaurant);
            if (existingRestaurant == null)
            {
                return Result<RestaurantResponse>.Failed("Restaurant not found");
            }

            _mapper.Map(request, existingRestaurant);

            existingRestaurant.UpdatedAt = DateTime.UtcNow;

            var result = await _restaurantRepository.UpdateAsync(existingRestaurant);

            var restaurantResponse = _mapper.Map<RestaurantResponse>(result);

            return Result<RestaurantResponse>.Ok(restaurantResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to update Restaurant: {message}", ex.Message);
            return Result<RestaurantResponse>.Failed("Failed to update restaurant");
        }
    }

    public async Task<Result<RestaurantResponse>> DeleteRestaurantAsync(string id)
    {
        _logger.Information("[SERVICE] Delete a restaurant with id: {id}", id);

        try
        {
            if(!Guid.TryParse(id.ToString(), out Guid idRestaurant))
            {
                return Result<RestaurantResponse>.Failed("Invalid ID Restaurant");
            }

            var existingRestaurant = await _restaurantRepository.GetByIdAsync(idRestaurant);
            if (existingRestaurant == null)
            {
                return Result<RestaurantResponse>.Failed("Restaurant not found");
            }
            else if (existingRestaurant.IsDeleted)
            {
                return Result<RestaurantResponse>.Failed($"Restaurant '{existingRestaurant.RestaurantName}' already deleted");
            }

            existingRestaurant.IsDeleted = true;
            existingRestaurant.UpdatedAt = DateTime.UtcNow;

            var result = await _restaurantRepository.UpdateAsync(existingRestaurant);

            var restaurantResponse = _mapper.Map<RestaurantResponse>(result);

            return Result<RestaurantResponse>.Ok(restaurantResponse);
        }
        catch (Exception ex)
        {
            _logger.Error("[SERVICE] Failed to delete Restaurant: {message}", ex.Message);
            return Result<RestaurantResponse>.Failed("Failed to delete restaurant");
        }
    }
}