using Serilog;

public class MainServiceRestaurantImplementation : IMainServiceRestaurant
{

    private readonly IRestaurantInfoState _restarantInfoState;
    private readonly Serilog.ILogger _logger;

    public MainServiceRestaurantImplementation(IRestaurantInfoState restaurantInfoSstate)
    {
        _restarantInfoState = restaurantInfoSstate;

        _logger = Log.ForContext<MainServiceRestaurantImplementation>();
    }

    public string GetRestaurantInfo()
    {
        _logger.Information("[GET RESTAURANT INFO] - Successfully retrieved the restaurant's info");
        return $"{_restarantInfoState.RestaurantName} - {_restarantInfoState.RestaurantAddress}";
    }
}