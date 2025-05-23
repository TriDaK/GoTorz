using Gotorz.Models;

namespace Gotorz.Services
{
    public interface IChatHttpService
    {
        Task<HttpResponseMessage> SendMessageAsync(ChatMessage message);
        Task<List<ChatMessage>> GetChatMessagesPerPackage(int packageId);
    }
}
