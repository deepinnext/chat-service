using Deepin.Chatting.Domain.ChatAggregate;
using MediatR;

namespace Deepin.Chatting.Domain.Events;

public record ChatMemberAddedDomainEvent(Chat Chat, ChatMember ChatMember) : INotification;