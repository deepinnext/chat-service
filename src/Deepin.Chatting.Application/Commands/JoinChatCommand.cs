using MediatR;

namespace Deepin.Chatting.Application.Commands;

public record JoinChatCommand(Guid Id, string UserId) : IRequest<bool>;