public class CreateMenuRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? Stock { get; set; }
    public decimal? Price { get; set; }
    public bool? IsActive { get; set; }
    public Guid RestaurantId { get; set; }
}