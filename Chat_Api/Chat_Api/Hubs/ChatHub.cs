using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Chat_Api.Hubs
{
    public class ChatHub : Hub
    {
        // Called when a client joins a chat group for a specific PackageId
        public Task JoinPackageGroup(string packageId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, packageId);
        }

        // Called when a client leaves the group
        public Task LeavePackageGroup(string packageId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, packageId);
        }

        // Optionally expose sending messages directly from client (less secure)
        public async Task SendMessage(string packageId, string userId, string message)
        {
            await Clients.Group(packageId).SendAsync("ReceiveMessage", new
            {
                PackageId = packageId,
                UserId = userId,
                Message = message,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
