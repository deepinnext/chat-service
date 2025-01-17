using Deepin.Chatting.Application.Models;

namespace Deepin.Chatting.Application.Queries;

public interface IChatQueries
{
    Task<IEnumerable<ChatDto>> GetChats(string userId);
    Task<ChatDto?> GetChatById(Guid chatId);
    Task<ChatMemberDto?> GetChatMember(Guid chatId, string userId);
}
