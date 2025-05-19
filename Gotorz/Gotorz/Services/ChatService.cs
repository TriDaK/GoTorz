
using Gotorz.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Gotorz.Services
{
    public class ChatService : IChatService
    {
        private HubConnection _hubConnection;

        public event Action<ChatMessage> OnMessageReceived;

        public async Task StartAsync(string packageId)
        {
            if (_hubConnection != null) return;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl("https://your-api-url/chathub") // TODO: Replace with actual API base URL
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<ChatMessage>("ReceiveMessage", message =>
            {
                OnMessageReceived?.Invoke(message);
            });

            await _hubConnection.StartAsync();
            await _hubConnection.InvokeAsync("JoinPackageGroup", packageId);
        }

        public async Task StopAsync(string packageId)
        {
            if (_hubConnection != null)
            {
                await _hubConnection.InvokeAsync("LeavePackageGroup", packageId);
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_hubConnection != null)
            {
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
            }
        }
    }
}
