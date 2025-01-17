using Deepin.Chatting.Domain.ChatAggregate;
using Deepin.Domain;

namespace Deepin.Chatting.Infrastructure.Repositories;

public class ChatRepository(ChattingDbContext db) : IChatRepository
{
    private readonly ChattingDbContext _db = db;
    public IUnitOfWork UnitOfWork =>_db;

    public Chat Add(Chat chat)
    {
        return _db.Chats.Add(chat).Entity;
    }

    public async Task<Chat?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _db.Chats.FindAsync([id], cancellationToken);
    }

    public Chat Update(Chat chat)
    {
        return _db.Chats.Update(chat).Entity;
    }
}
