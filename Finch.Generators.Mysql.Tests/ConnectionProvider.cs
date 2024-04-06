using Finch.Tests.Shared;
using MySql.Data.MySqlClient;

namespace Finch.Generators.Mysql.Tests;

public static class NpgsqlConnectionProvider
{
    public static MySqlConnection Create()
    {
        var connectionString = Constants.MysqlConnectionString;
        var connection = new MySqlConnection(connectionString);
        return connection;
    }
}