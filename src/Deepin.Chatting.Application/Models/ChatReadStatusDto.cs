namespace Deepin.Chatting.Application.Models;

public class ChatReadStatusDto
{
    public Guid ChatId { get; set; }
    public string UserId { get; set; }
    public string LastReadMessageId { get; set; }
    public DateTime LastReadAt { get; set; }
}
