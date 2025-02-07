using Microsoft.AspNetCore.SignalR;

namespace SpreeviewFrontend.Hubs.Chat;

public class ChatHub : Hub
{
    /// <summary>
    /// Broadcast a message to all clients in the hub. 
    /// </summary>
    /// <param name="message">The chat message to be sent</param>
    public async Task SendMessage(ChatMessage message)
    {
        // Broadcast a message to all clients, using RecieveMessage, user, and message.
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}