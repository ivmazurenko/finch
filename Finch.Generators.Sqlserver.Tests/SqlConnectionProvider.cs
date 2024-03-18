using Microsoft.Data.SqlClient;

namespace Finch.Generators.Sqlserver.Tests;

public static class SqlConnectionProvider
{
    public static SqlConnection Create()
    {
        const string connectionString =
            "Server=192.168.124.41,1433;User Id=SA;Password=vEryL111ngOassw1e!;Database=mock_database;Encrypt=false";
        var connection = new SqlConnection(connectionString);
        return connection;
    }
}