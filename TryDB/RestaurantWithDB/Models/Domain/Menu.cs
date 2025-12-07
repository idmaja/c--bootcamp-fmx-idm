using System.ComponentModel.DataAnnotations;

public class Menu
{
    public Guid Id { get; private set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(1000)]
    public string? Description { get; set;}
    [Required]
    public int Stock { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public bool IsDeleted { get; set; }
    public Guid RestaurantId { get; set; }
    public Restaurant? Restaurant { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Menu()
    {
        Id = Guid.NewGuid();
    }
}