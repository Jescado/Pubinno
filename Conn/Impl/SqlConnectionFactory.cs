using System.Data;
using System.Data.SqlClient;

namespace Conn.Impl
{
    public class SqlConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string connString;

        public SqlConnectionFactory(string connString)
        {
            this.connString = connString;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConn = new SqlConnection(connString);
            await sqlConn.OpenAsync();
            return sqlConn;
        }
    }
}
