using Blazored.SessionStorage;

namespace Gotorz.Services
{
    // This storage type keeps tokens by session, not persistently.
    public class SessionStorageTokenService : ITokenService
    {
        private readonly ISessionStorageService _storage;
        private const string TokenKey = "jwt_token";

        public SessionStorageTokenService(ISessionStorageService storage)
        {
            _storage = storage;
        }

        public async Task StoreTokenAsync(string token)
        {
            await _storage.SetItemAsync(TokenKey, token);
        }

        public async Task<string> GetTokenAsync()
        {
            return await _storage.GetItemAsync<string>(TokenKey);
        }
    }
}
