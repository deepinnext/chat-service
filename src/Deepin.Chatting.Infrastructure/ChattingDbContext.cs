using Deepin.Chatting.Domain.ChatAggregate;
using Deepin.Chatting.Infrastructure.EntityTypeConfigurations;
using Deepin.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Deepin.Chatting.Infrastructure;

public class ChattingDbContext : DbContextBase<ChattingDbContext>
{
    public ChattingDbContext(DbContextOptions<ChattingDbContext> options, IMediator? mediator = null) : base(options, mediator)
    {
    }
    public DbSet<Chat> Chats { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("chatting");
        modelBuilder.ApplyConfiguration(new ChatEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ChatMemberEntityTypeConfiguration());
    }
}
