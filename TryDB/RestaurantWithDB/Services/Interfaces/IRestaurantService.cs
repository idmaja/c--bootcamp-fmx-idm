public interface IRestaurantService
{
    Task<Result<IEnumerable<RestaurantResponse>>> GetAllRestaurantsAsync();
    Task<Result<RestaurantResponse>> GetRestaurantByIdAsync(string id);
    Task<Result<RestaurantResponse>> CreateRestaurantAsync(CreateRestaurantRequest request);
    Task<Result<RestaurantResponse>> UpdateRestaurantAsync(string id, UpdateRestaurantRequest request);
    Task<Result<RestaurantResponse>> DeleteRestaurantAsync(string id);
}