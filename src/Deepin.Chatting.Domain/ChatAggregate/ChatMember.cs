using Deepin.Domain;

namespace Deepin.Chatting.Domain.ChatAggregate;
public class ChatMember : Entity<Guid>
{
    public string UserId { get; private set; }
    public string? DisplayName { get; private set; }
    public DateTime JoinedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public ChatMemberRole Role { get; private set; }
    public ChatMember()
    {
        UserId = string.Empty;
        JoinedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }
    public ChatMember(string userId, ChatMemberRole role, string? displayName = null) : this()
    {
        UserId = userId;
        Role = role;
        DisplayName = displayName ?? string.Empty;
    }
}
