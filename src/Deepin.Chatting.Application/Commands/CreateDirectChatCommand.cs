using Deepin.Chatting.Application.Models;
using MediatR;

namespace Deepin.Chatting.Application.Commands;

public record CreateDirectChatCommand(string[] UserIds) : IRequest<ChatDto>;
