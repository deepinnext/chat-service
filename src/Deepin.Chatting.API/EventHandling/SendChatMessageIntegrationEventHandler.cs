using Deepin.Chatting.API.Hubs;
using Deepin.EventBus;
using Deepin.EventBus.Events;
using MassTransit;
using Microsoft.AspNetCore.SignalR;

namespace Deepin.Chatting.API.EventHandling;

public class SendChatMessageIntegrationEventHandler(ILogger<SendChatMessageIntegrationEventHandler> logger, IHubContext<ChatsHub> chatsHub) : IIntegrationEventHandler<SendChatMessageIntegrationEvent>
{
    private readonly ILogger<SendChatMessageIntegrationEventHandler> _logger = logger;
    private readonly IHubContext<ChatsHub> _chatsHub = chatsHub;
    public async Task Consume(ConsumeContext<SendChatMessageIntegrationEvent> context)
    {
        try
        {
            var chatMessage = context.Message;
            await _chatsHub.Clients.Group(chatMessage.ChatId).SendAsync("ReceiveMessage", chatMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while sending message to chat");
        }
    }
}
