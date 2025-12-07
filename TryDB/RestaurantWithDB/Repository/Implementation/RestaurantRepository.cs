using Microsoft.EntityFrameworkCore;
using Serilog;

public class RestaurantRepository : IRestaurantRepository
{
    private readonly RestaurantDbContext _context;

    private readonly Serilog.ILogger _logger;

    public RestaurantRepository(RestaurantDbContext context)
    {
        _context = context;
        _logger = Log.ForContext<RestaurantRepository>();
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        _logger.Information("[REPO] Get all restaurant(s)");

        return await _context.Restaurants
                    .Include(restaurant => restaurant.Menus)
                    .ToListAsync();
    }

    public async Task<Restaurant?> GetByIdAsync(Guid id)
    {
        _logger.Information("[REPO] Get a restaurant by id: {id}", id);

        return await _context.Restaurants
                    .Include(restaurant => restaurant.Menus)
                    .FirstOrDefaultAsync(restaurant => restaurant.Id == id);
    }

    public async Task<Restaurant> AddAsync(Restaurant restaurant)
    {
        _logger.Information("[REPO] Create a restaurant with id: {id}", restaurant.Id);

        _context.Restaurants.Add(restaurant);

        await _context.SaveChangesAsync();

        return restaurant;
    }

    public async Task<Restaurant?> UpdateAsync(Restaurant restaurant)
    {
        _logger.Information("[REPO] Update a restaurant with id: {id}", restaurant.Id);

        _context.Restaurants.Update(restaurant);

        await _context.SaveChangesAsync();

        return restaurant;
    }
}
