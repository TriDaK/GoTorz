using Gotorz.Models;

namespace Gotorz.Services
{
    public interface IChatService : IAsyncDisposable
    {
        event Action<ChatMessage> OnMessageReceived;

        Task StartAsync(string packageId);
        Task StopAsync(string packageId);
    }
}
