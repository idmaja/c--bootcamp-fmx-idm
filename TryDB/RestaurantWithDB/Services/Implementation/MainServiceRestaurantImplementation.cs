using Serilog;

public class MainServiceRestaurantImplementation : IMainServiceRestaurant
{

    private readonly Serilog.ILogger _logger;

    private readonly RestaurantDbContext _db;

    public MainServiceRestaurantImplementation(RestaurantDbContext db)
    {
        _db = db;
        _logger = Log.ForContext<MainServiceRestaurantImplementation>();
    }

    public string GetRestaurantInfo()
    {
        _logger.Information("[GET RESTAURANT INFO] - Successfully retrieved the restaurant's info");
        return $"";
    }
}