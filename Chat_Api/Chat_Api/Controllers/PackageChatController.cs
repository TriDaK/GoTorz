using Chat_Api.Data;
using Chat_Api.Hubs;
using Chat_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chat_Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PackageChatController : ControllerBase
    {
        private readonly ChatDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public PackageChatController(ChatDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // GET: api/packagechat
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetPackageChats()
        {
            // This likely should never be called, at least until we get deep into admin features. 
            return Ok("API/GET for all PackageChats");
        }

        // GET: api/packagechat/{packageId}
        [HttpGet("{packageId}")]
        public async Task<ActionResult<IEnumerable<ChatMessage>>> GetPackageChat(string packageId)
        {
            return Ok(await _context.Messages
                .Where(m => m.PackageId == int.Parse(packageId))
                .OrderByDescending(m => m.Timestamp)
                .ToListAsync());
        }

        // POST: api/packagechat/{packageId}/message
        [HttpPost("{packageId}/message")]
        public async Task<IActionResult> PostPackageChatMessage(string packageId, [FromBody] ChatMessage message)
        {
            message.Timestamp = DateTime.UtcNow;

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            // Broadcast to all clients in this package group
            await _hubContext.Clients.Group(packageId)
                .SendAsync("ReceiveMessage", message);

            return Ok(message);
        }
    }
}
