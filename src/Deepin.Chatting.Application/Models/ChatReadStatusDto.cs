namespace Deepin.Chatting.Application.Models;

public class ChatReadStatusDto
{
    public Guid ChatId { get; set; }
    public required string UserId { get; set; }
    public required string LastReadMessageId { get; set; }
    public DateTime LastReadAt { get; set; }
}
