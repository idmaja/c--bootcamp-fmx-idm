using Microsoft.AspNetCore.Identity;

public class AuthResponse
{
    public AccountResponse? User { get; set; }
    public string? Token { get; set; }
}