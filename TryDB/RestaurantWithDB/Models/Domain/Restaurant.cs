
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class Restaurant
{
    public Guid Id { get; private set; }
    [Required]
    public string? OwnerId { get; set; }
    public IdentityUser? Owner { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string? RestaurantName { get; set; }
    [Required]
    public string? RestaurantAddress { get; set; }
    [Required]
    public bool IsActive { get; set; } = true;
    [Required]
    public bool IsDeleted { get; set; } = false;
    public ICollection<Menu>? Menus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Restaurant()
    {
        Id = Guid.NewGuid();
    }
}
