using Company.Product.Application.Abstractions.Persistence;
using Dapper;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Company.Product.Infrastructure.Health;

internal sealed class DatabaseHealthCheck(
    IDbConnectionFactory connectionFactory)
    : IHealthCheck
{
    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection =
                await connectionFactory.OpenConnectionAsync(cancellationToken);

            var result = await connection.ExecuteScalarAsync<int>(
                new CommandDefinition(
                    "SELECT 1;",
                    cancellationToken: cancellationToken));

            return result == 1
                ? HealthCheckResult.Healthy("Database connection successful.")
                : HealthCheckResult.Unhealthy("Database health query failed.");
        }
        catch (Exception exception)
        {
            return HealthCheckResult.Unhealthy(
                "Database connection failed.",
                exception);
        }
    }
}
