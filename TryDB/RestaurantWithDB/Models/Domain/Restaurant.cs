
public class Restaurant
{
    public Guid Id { get; set; } = Guid.Empty;
    public IEnumerable<string> ChefName { get; set; } = new List<string>();
    public string RestaurantName { get; set; } = string.Empty;
    public string RestaurantAddress { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
}
