using System.Data;

namespace Conn
{
    public interface IDatabaseConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
