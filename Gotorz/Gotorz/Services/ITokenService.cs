namespace Gotorz.Services
{
    public interface ITokenService
    {
        Task StoreTokenAsync(string token);
        Task<string> GetTokenAsync();
    }
}
