public interface IAuthService
{
    Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, string role = "user");
    Task<Result<AuthResponse>> LoginAsync(LoginRequest request);
}