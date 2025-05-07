using Microsoft.AspNetCore.SignalR;

namespace Gotorz.Hubs
{
    public class PackageChatHub : Hub
    {
        public async Task JoinRoom (string packageId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, packageId);
        }

        public async Task SendMessage(string packageId, string user, string message)
        {
            await Clients.Group(packageId).SendAsync("ReceiveMessage", user, message);
        }
    }
}
