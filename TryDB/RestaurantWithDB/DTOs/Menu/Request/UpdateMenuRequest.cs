public class UpdateMenuRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
}