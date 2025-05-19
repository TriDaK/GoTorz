using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace Chat_Api.Hubs
{
    public class ChatHub : Hub
    {
        // Called when a client joins a chat group for a specific PackageId
        public Task JoinPackageGroup(int packageId)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, packageId.ToString());
        }

        // Called when a client leaves the group
        public Task LeavePackageGroup(int packageId)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, packageId.ToString());
        }

        // Optionally expose sending messages directly from client (less secure)
        public async Task SendMessage(int packageId, string userId, string message)
        {
            await Clients.Group(packageId.ToString()).SendAsync("ReceiveMessage", new
            {
                PackageId = packageId,
                UserId = userId,
                Message = message,
                Timestamp = DateTime.UtcNow
            });
        }
    }
}
