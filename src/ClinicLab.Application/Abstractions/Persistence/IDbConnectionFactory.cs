using System.Data.Common;

namespace ClinicLab.Application.Abstractions.Persistence;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync(
        CancellationToken cancellationToken = default);
}
