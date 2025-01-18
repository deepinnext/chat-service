using Deepin.Chatting.API.Hubs;
using Deepin.Chatting.Application.Extensions;
using Deepin.Chatting.Infrastructure;
using Deepin.Chatting.Infrastructure.Extensions;
using Deepin.EventBus.RabbitMQ;
using Deepin.Infrastructure.Extensions;
using Deepin.ServiceDefaults.Extensions;
using Microsoft.AspNetCore.DataProtection;
using StackExchange.Redis;

namespace Deepin.Chatting.API.Extensions;

public static class HostExtensions
{
    public static WebApplicationBuilder AddApplicationService(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection");
        builder.AddServiceDefaults();
        builder.Services
        .AddChattingDbContext(connectionString)
        .AddEventBusRabbitMQ(
            builder.Configuration.GetSection(RabbitMqOptions.ConfigurationKey).Get<RabbitMqOptions>() ?? throw new ArgumentNullException("RabbitMQ"),
            assembly: typeof(HostExtensions).Assembly)
        .AddMigration<ChattingDbContext>()
        .AddApplication(connectionString)
        .AddDefaultCache(builder.Configuration.GetConnectionString("Redis"))
        .AddDefaultUserContexts()
        .AddCustomSignalR(builder.Configuration);

        return builder;
    }
    public static WebApplication UseApplicationService(this WebApplication app)
    {
        app.UseServiceDefaults();

        app.MapHub<ChatsHub>("/hub/chats");
        app.MapGet("/api/about", () => new
        {
            Name = "Deepin.Chatting.API",
            Version = "1.0.0",
            DeepinEnv = app.Configuration["DEEPIN_ENV"],
            app.Environment.EnvironmentName
        });
        return app;
    }
    private static IServiceCollection AddCustomSignalR(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConnection = configuration.GetConnectionString("RedisConnection");
        if (!string.IsNullOrEmpty(redisConnection))
        {
            services.AddDataProtection(opts =>
            {
                opts.ApplicationDiscriminator = "Deepin.Chatting.API";
            })
             .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(redisConnection), "Deepin.Chatting.API.DataProtection.Keys");

            services.AddSignalR().AddStackExchangeRedis(redisConnection, options => { });
        }
        else
        {
            services.AddSignalR();
        }
        return services;
    }
}