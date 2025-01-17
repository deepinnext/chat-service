using System.Security.Claims;
using Deepin.Chatting.Application.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Deepin.Chatting.API.Hubs;

[Authorize]
public class ChatsHub(IChatQueries chatQueries) : Hub
{
    private readonly IChatQueries _chatQueries = chatQueries;
    private string? _userId = null;
    public string? UserId
    {
        get
        {
            if (string.IsNullOrEmpty(_userId))
            {
                _userId = Context.User?.FindFirst("sub")?.Value;
            }
            if (string.IsNullOrEmpty(_userId))
            {
                _userId = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
            return _userId;
        }
    }
    public override async Task OnConnectedAsync()
    {
        var chats = await _chatQueries.GetChats(UserId ?? throw new ArgumentNullException(nameof(UserId)));
        foreach (var chat in chats)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id.ToString());
        }
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var chats = await _chatQueries.GetChats(UserId ?? throw new ArgumentNullException(nameof(UserId)));
        foreach (var chat in chats)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, chat.Id.ToString());
        }
        await base.OnDisconnectedAsync(exception);
    }
}
