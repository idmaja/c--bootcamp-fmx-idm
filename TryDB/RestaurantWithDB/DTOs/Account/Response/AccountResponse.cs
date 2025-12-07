public class AccountResponse
{
    public string? AccountId { get; set; }
    public string? Username { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public IList<string>? Roles { get; set; }
}