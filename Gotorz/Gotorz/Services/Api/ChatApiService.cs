using Gotorz.Models;

namespace Gotorz.Services.Api
{
    public class ChatApiService
    {
        private readonly HttpClient _httpClient;

        public ChatApiService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ChatAPI");
        }

        public Task<HttpResponseMessage> SendMessageAsync(ChatMessage message)
        {
            return _httpClient.PostAsJsonAsync($"api/packagechat/{message.PackageId}/message", message);
        }
    }
}
