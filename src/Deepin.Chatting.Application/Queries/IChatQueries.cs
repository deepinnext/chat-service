using Deepin.Application.Pagination;
using Deepin.Chatting.Application.Models;

namespace Deepin.Chatting.Application.Queries;

public interface IChatQueries
{
    Task<IEnumerable<ChatDto>> GetChats(string userId);
    Task<ChatDto?> GetChatById(Guid chatId);
    Task<ChatMemberDto?> GetChatMember(Guid chatId, string userId);
    Task<IPagination<ChatMemberDto>> GetChatMembers(Guid chatId, int offset, int limit);
    Task<IEnumerable<ChatReadStatusDto>> GetChatReadStatusesAsync(string userId);
    Task<ChatReadStatusDto> GetChatReadStatusAsync(Guid chatId, string userId);
}
