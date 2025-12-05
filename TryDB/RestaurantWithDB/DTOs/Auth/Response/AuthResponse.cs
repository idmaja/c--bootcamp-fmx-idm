using Microsoft.AspNetCore.Identity;

public class AuthResponse
{
    public IdentityUser? User { get; set; }
    public string? Token { get; set; }
}