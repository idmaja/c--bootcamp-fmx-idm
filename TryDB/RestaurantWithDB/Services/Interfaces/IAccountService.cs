using Microsoft.AspNetCore.Identity;

public interface IAccountService
{
    Task<Result<IEnumerable<AccountResponse>>> GetAllAccountsAsync();
    Task<Result<AccountResponse>> GetAccountByIdAsync(string id);
    Task<Result<AccountResponse>> CreateAccountAsync(CreateAccountRequest request);
    Task<Result<AccountResponse>> UpdateAccountAsync(string id, UpdateAccountRequest request);
}