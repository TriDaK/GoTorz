using Gotorz.Models;
using System.Linq.Expressions;

namespace Gotorz.Services
{
    public class ChatHttpService : IChatHttpService
    {
        private readonly HttpClient _httpClient;

        public ChatHttpService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ChatAPI");
        }

        public Task<HttpResponseMessage> SendMessageAsync(ChatMessage message)
        {
            return _httpClient.PostAsJsonAsync($"api/packagechat/{message.PackageId}/message", message);
        }

        public async Task<List<ChatMessage>> GetChatMessagesPerPackage(int packageId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<ChatMessage>>($"api/PackageChat/{packageId}") ?? new List<ChatMessage>();

            }
            catch // if no respons 
            {
                return new List<ChatMessage>();
            }
        }
    }
}
