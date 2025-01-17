using Deepin.Chatting.Domain.ChatAggregate;
using MediatR;

namespace Deepin.Chatting.Domain.Events;

public record ChatCreatedDomainEvent(Chat Chat) : INotification;