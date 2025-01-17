using Dapper;
using Deepin.Chatting.Application.Constants;
using Deepin.Chatting.Application.Models;
using Deepin.Chatting.Domain.ChatAggregate;
using Deepin.Infrastructure.Extensions;
using Microsoft.Extensions.Caching.Distributed;
using Npgsql;

namespace Deepin.Chatting.Application.Queries;

public class ChatQueries(string connectionString, IDistributedCache cache) : QueryBase, IChatQueries
{
    private readonly string _connectionString = connectionString;
    private readonly IDistributedCache _cache = cache;

    public async Task<IEnumerable<ChatDto>> GetChats(string userId)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var sql = @"SELECT c.* FROM chats c 
                        JOIN chat_member cm ON c.id = cm.chat_id
                        WHERE c.is_deleted = false AND cm.user_id = @userId";
            var result = await connection.QueryAsync<dynamic>(BuildSqlWithSchema(sql), new { userId });
            return result.Select(MapChatDto);
        }
    }
    public async Task<ChatDto?> GetChatById(Guid id)
    {
        return await _cache.GetOrCreateAsync(CacheKeys.GetChatByIdCacheKey(id), async () =>
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var sql = @"SELECT * FROM chats WHERE id = @id";
                var result = await connection.QueryFirstOrDefaultAsync<dynamic>(BuildSqlWithSchema(sql), new { id });
                return result != null ? MapChatDto(result) : null;
            }
        });
    }
    public async Task<ChatMemberDto?> GetChatMember(Guid chatId, string userId)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            connection.Open();
            var sql = @"SELECT chat_id ChatId, user_id UserId, is_admin IsAdmin, is_deleted IsDeleted, created_at CreatedAt, updated_at UpdatedAt FROM chat_members WHERE chat_id = @chatId AND user_id = @userId";
            return await connection.QueryFirstOrDefaultAsync<ChatMemberDto>(BuildSqlWithSchema(sql), new { chatId, userId });
        }
    }
    private ChatDto MapChatDto(dynamic result)
    {
        var dto = new ChatDto
        {
            Id = result.id,
            Type = result.type,
            CreatedAt = result.created_at,
            UpdatedAt = result.updated_at,
            CreatedBy = result.created_by,
            IsDeleted = result.is_deleted
        };
        ChatType chatType = Enum.Parse<ChatType>(result.type, true);
        if (chatType != ChatType.Direct)
        {
            dto.GroupInfo = new ChatInfo
            {
                Name = result.name,
                AvatarFileId = result.avatar_file_id,
                Description = result.description,
                IsPublic = result.is_public,
                UserName = result.user_name
            };
        }
        return dto;
    }
}
