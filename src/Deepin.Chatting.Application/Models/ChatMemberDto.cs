using Deepin.Chatting.Domain.ChatAggregate;

namespace Deepin.Chatting.Application.Models;

public class ChatMemberDto
{
    public required string UserId { get; set; }
    public string? DisplayName { get; set; }
    public DateTime JoinedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ChatMemberRole Role { get; set; }
}
