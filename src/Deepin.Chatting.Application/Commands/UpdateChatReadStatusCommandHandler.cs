using Deepin.Chatting.Domain.ChatAggregate;
using Deepin.Chatting.Infrastructure;
using Deepin.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Deepin.Chatting.Application.Commands;

public class UpdateChatReadStatusCommandHandler(
    ChattingDbContext chattingDbContext,
    IUserContext userContext) : IRequestHandler<UpdateChatReadStatusCommand, bool>
{
    private readonly ChattingDbContext _chattingDbContext = chattingDbContext;
    private readonly IUserContext _userContext = userContext;
    public async Task<bool> Handle(UpdateChatReadStatusCommand request, CancellationToken cancellationToken)
    {
        var chatReadStatus = await _chattingDbContext.ChatReadStatuses
            .FirstOrDefaultAsync(x => x.ChatId == request.ChatId && x.UserId == _userContext.UserId, cancellationToken);
        if (chatReadStatus is null)
        {
            chatReadStatus = new ChatReadStatus(request.ChatId, _userContext.UserId, request.MessageId);
            _chattingDbContext.ChatReadStatuses.Add(chatReadStatus);
        }
        else
        {
            chatReadStatus.ReadMessage(request.MessageId);
        }
        await _chattingDbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
}
