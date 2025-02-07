namespace SpreeviewFrontend.Hubs.Chat;

public class ChatMessage
{
    public string Message { get; set; } = null!;
    public string User { get; set; } = null!;
    public TimeOnly Time { get; set; } = TimeOnly.FromTimeSpan(TimeSpan.Zero);
}