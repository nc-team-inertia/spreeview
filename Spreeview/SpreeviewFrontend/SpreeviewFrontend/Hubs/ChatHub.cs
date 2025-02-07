using Microsoft.AspNetCore.SignalR;

namespace SpreeviewFrontend.Hubs;

public class ChatHub : Hub
{
    /// <summary>
    /// Broadcast a message to all clients in the hub. 
    /// </summary>
    /// <param name="user">The name of the user</param>
    /// <param name="message">The message contents</param>
    public async Task SendMessage(string user, string message)
    {
        // Broadcast a message to all clients, using RecieveMessage, user, and message.
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}