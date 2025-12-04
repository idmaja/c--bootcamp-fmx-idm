using System.ComponentModel.DataAnnotations;

public class Menu
{
    public Guid Id { get; private set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    [Required]
    [MaxLength(1000)]
    public string? Description { get; set;}
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Menu()
    {
        Id = Guid.NewGuid();
    }
}