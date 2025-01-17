using Deepin.Chatting.Application.Models;
using Deepin.Chatting.Domain.ChatAggregate;
using MediatR;

namespace Deepin.Chatting.Application.Commands;

public class CreateChatCommand : IRequest<ChatDto>
{
    public required string Name { get; set; }
    public string? UserName { get; set; }
    public string? Description { get; set; }
    public string? AvatarFileId { get; set; }
    public bool IsPublic { get; set; }
    public ChatType Type { get; set; } 
}
