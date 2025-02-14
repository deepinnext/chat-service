using MediatR;

namespace Deepin.Chatting.Application.Commands;

public record UpdateChatReadStatusCommand(Guid ChatId, string MessageId) : IRequest<bool>;
