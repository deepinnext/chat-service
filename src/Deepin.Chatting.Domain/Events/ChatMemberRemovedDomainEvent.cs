using Deepin.Chatting.Domain.ChatAggregate;
using MediatR;

namespace Deepin.Chatting.Domain.Events;

public record ChatMemberRemovedDomainEvent(Chat Chat, ChatMember ChatMember) : INotification;