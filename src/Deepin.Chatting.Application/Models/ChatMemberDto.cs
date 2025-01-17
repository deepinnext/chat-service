namespace Deepin.Chatting.Application.Models;

public class ChatMemberDto
{
    public required string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsOwner { get; set; }
    public bool IsAdmin { get; set; }
}
