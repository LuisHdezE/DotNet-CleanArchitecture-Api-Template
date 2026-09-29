using Company.Product.Application.Abstractions.Persistence;
using Company.Product.Infrastructure.Health;
using Company.Product.Infrastructure.Persistence.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Product.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException(
                "Connection string 'DefaultConnection' was not found.");

        services.AddSingleton<IDbConnectionFactory>(
            _ => new SqlConnectionFactory(connectionString));
        services
    .AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("database");

        return services;
    }
}
