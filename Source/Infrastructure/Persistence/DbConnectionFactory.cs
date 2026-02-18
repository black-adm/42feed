using Microsoft.Data.SqlClient;
using System.Data;

namespace Infrastructure.Persistence;

internal sealed class DbConnectionFactory(string connectionString)
{
    private readonly string _connectionString = connectionString;

    public IDbConnection CreateOpenConnection()
    {
        var connection = new SqlConnection(_connectionString);

        connection.Open();

        return connection;
    }
}
