using Microsoft.Data.SqlClient;

namespace Finch.Generators.Sqlserver.Tests;

public static class ConnectionProvider
{
    public static SqlConnection Create()
    {
        var connectionString = Finch.Tests.Shared.Constants.SqlserverConnectionString;
        var connection = new SqlConnection(connectionString);
        return connection;
    }
}