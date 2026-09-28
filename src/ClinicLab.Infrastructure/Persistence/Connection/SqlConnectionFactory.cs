using ClinicLab.Application.Abstractions.Persistence;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace ClinicLab.Infrastructure.Persistence.Connection;

internal sealed class SqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async ValueTask<DbConnection> OpenConnectionAsync(
        CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(_connectionString);

        await connection.OpenAsync(cancellationToken);

        return connection;
    }
}