using Deepin.Domain;

namespace Deepin.Chatting.Domain.ChatAggregate;
public class ChatMember : Entity<Guid>
{
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsOwner { get; set; }
    public bool IsAdmin { get; set; }
    public ChatMember()
    {
        UserId = string.Empty;
        CreatedAt = DateTime.UtcNow;
    }
    public ChatMember(string userId, bool isOwner = false, bool isAdmin = false) : this()
    {
        UserId = userId;
        IsOwner = isOwner;
        IsAdmin = isAdmin;
    }
}
