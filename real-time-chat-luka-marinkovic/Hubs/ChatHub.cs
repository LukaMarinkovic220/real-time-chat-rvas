using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task Send(string senderId, string receiverId, string message)
    {
        await Clients.User(receiverId).SendAsync("ReceiveMessage", senderId, message);
        await Clients.User(senderId).SendAsync("ReceiveMessage", senderId, message);
    }
}