public class RestaurantResponse
{
    public string? Id { get; set; }
    public string? OwnerId { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ICollection<MenuResponse>? Menus { get; set; }
}