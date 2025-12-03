using Microsoft.EntityFrameworkCore;

public class RestaurantDbContext : DbContext
{
    public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options) { }

    public DbSet<RestaurantInfoState> RestaurantInfos { get; set; }
}