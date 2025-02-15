using Deepin.Chatting.Domain.ChatAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Deepin.Chatting.Infrastructure.EntityTypeConfigurations;

public class ChatReadStatusEntityTypeConfiguration : IEntityTypeConfiguration<ChatReadStatus>
{
    public void Configure(EntityTypeBuilder<ChatReadStatus> builder)
    {
        builder.ToTable("chat_read_statuses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").HasColumnType("uuid").HasValueGenerator(typeof(SequentialGuidValueGenerator));

        builder.Property(x => x.UserId).HasColumnName("user_id").IsRequired();
        builder.Property(x => x.LastReadAt).HasColumnName("last_read_at").HasColumnType("timestamp with time zone");
        builder.Property(x => x.LastReadMessageId).HasColumnName("last_read_message_id").IsRequired();
        builder.Property(x => x.ChatId).HasColumnName("chat_id").HasColumnType("uuid").IsRequired();
    }
}
