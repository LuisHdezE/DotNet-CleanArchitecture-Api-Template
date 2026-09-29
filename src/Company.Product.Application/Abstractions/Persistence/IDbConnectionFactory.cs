using System.Data.Common;

namespace Company.Product.Application.Abstractions.Persistence;

public interface IDbConnectionFactory
{
    ValueTask<DbConnection> OpenConnectionAsync(
        CancellationToken cancellationToken = default);
}
