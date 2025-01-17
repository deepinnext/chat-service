using Deepin.Chatting.Domain.ChatAggregate;
using MediatR;

namespace Deepin.Chatting.Domain.Events;

public record ChatGroupInfoUpdatedDomainEvent(Chat Chat) : INotification;