using Microsoft.AspNetCore.SignalR;

namespace SpreeviewFrontend.Services.Chat;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        // Broadcast a message to all clients, using RecieveMessage, user, and message.
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}