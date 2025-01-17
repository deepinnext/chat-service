using Deepin.Chatting.Application.Queries;
using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Deepin.Chatting.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString)
    {
        var assembly = typeof(ServiceCollectionExtensions).Assembly;

        services
        .AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(assembly);
        })
        .AddValidatorsFromAssembly(assembly)
        .AddAutoMapper(assembly)
        .AddQueries(connectionString);
        return services;
    }
    private static IServiceCollection AddQueries(this IServiceCollection services, string connectionString)
    {
        services.AddScoped<IChatQueries>(sp => new ChatQueries(connectionString, sp.GetRequiredService<IDistributedCache>()));
        return services;
    }
}
