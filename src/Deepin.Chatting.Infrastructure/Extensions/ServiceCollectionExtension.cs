using Deepin.Chatting.Domain.ChatAggregate;
using Deepin.Chatting.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Deepin.Chatting.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddChattingDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ChattingDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IChatRepository, ChatRepository>();
        return services;
    }
}
