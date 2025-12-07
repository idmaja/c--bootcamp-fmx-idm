public class UpdateRestaurantRequest
{
    public string? OwnerId { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
}