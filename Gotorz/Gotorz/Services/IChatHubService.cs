using Gotorz.Models;

namespace Gotorz.Services
{
    public interface IChatHubService : IAsyncDisposable
    {
        event Action<ChatMessage> OnMessageReceived;

        Task StartAsync(int packageId);
        Task StopAsync(int packageId);
    }
}
