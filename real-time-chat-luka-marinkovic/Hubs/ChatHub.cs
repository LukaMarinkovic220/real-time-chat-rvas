using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using real_time_chat_luka_marinkovic.Data;
using real_time_chat_luka_marinkovic.Models;

public class ChatHub : Hub
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public ChatHub(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task JoinChat(string chatGroupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatGroupName);
    }

    public async Task SendMessage(string senderId, string receiverId, string message, string chatGroupName)
    {
        var msg = new Message
        {
            SenderId = senderId,
            ReceiverId = receiverId,
            Content = message,
            Timestamp = DateTime.Now
        };

        _context.Messages.Add(msg);
        await _context.SaveChangesAsync();

        await Clients.Group(chatGroupName).SendAsync("ReceiveMessage", senderId, message);
    }

    public override Task OnConnectedAsync()
    {
        // povezivanje korisnika po id
        var userId = Context.UserIdentifier;
        return base.OnConnectedAsync();
    }
}