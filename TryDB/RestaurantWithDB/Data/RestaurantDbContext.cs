using Microsoft.EntityFrameworkCore;

public class RestaurantDbContext : DbContext
{
    public DbSet<Menu> Menus { get; set; }
    public DbSet<Restaurant> Restaurants { get; set; }    
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

}