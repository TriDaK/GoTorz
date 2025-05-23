﻿
using Gotorz.Models;
using Microsoft.AspNetCore.SignalR.Client;

namespace Gotorz.Services
{
    public class ChatHubService : IChatHubService
    {
        private readonly IConfiguration _config;
        private HubConnection _hubConnection;

        public event Action<ChatMessage> OnMessageReceived;

        public ChatHubService(IConfiguration config)
        {
            _config = config;
        }

        public async Task StartAsync(int packageId)
        {
            if (_hubConnection != null) return;
            string hubUrl = $"{_config["Urls:ChatApi"]}chathub";

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl) // Maybe needs to be handled differently?
                .WithAutomaticReconnect()
                .Build();

            _hubConnection.On<ChatMessage>("ReceiveMessage", message =>
            {
                OnMessageReceived?.Invoke(message);
            });

            await _hubConnection.StartAsync();
            await _hubConnection.InvokeAsync("JoinPackageGroup", packageId);
        }

        public async Task StopAsync(int packageId)
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
