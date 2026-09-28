using ClinicLab.Application.Abstractions.Persistence;
using ClinicLab.Infrastructure.Health;
using ClinicLab.Infrastructure.Persistence.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicLab.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ClinicLab")
            ?? throw new InvalidOperationException(
                "Connection string 'ClinicLab' was not found.");

        services.AddSingleton<IDbConnectionFactory>(
            _ => new SqlConnectionFactory(connectionString));
        services
    .AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("database");

        return services;
    }
}
