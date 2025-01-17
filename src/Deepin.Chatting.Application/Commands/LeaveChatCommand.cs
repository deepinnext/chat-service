using System;
using MediatR;

namespace Deepin.Chatting.Application.Commands;

public record LeaveChatCommand(Guid Id, string UserId) : IRequest<bool>;