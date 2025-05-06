using Package_Api.Models.Login;

namespace Package_Api.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(UserLogin user);
        Task<bool> Login(UserLogin user);
        string GenerateTokenString(UserLogin user);
    }
}