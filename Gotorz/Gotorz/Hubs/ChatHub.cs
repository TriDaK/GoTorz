using Microsoft.AspNetCore.SignalR;

namespace Gotorz.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message); // ReceiveMessage is he name of the methode for the client in SignalR
        }
    }
}
