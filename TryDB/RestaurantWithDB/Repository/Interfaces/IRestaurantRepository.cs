public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(Guid id);
    Task<Restaurant> AddAsync(Restaurant restaurant);
    Task<Restaurant?> UpdateAsync(Restaurant restaurant);
}