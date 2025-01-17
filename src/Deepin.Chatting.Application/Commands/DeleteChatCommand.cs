using MediatR;

namespace Deepin.Chatting.Application.Commands;

public record DeleteChatCommand(Guid Id) : IRequest<bool>;