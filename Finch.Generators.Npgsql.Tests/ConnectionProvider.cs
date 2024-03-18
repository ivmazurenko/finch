using Finch.Tests.Shared;
using Npgsql;

namespace Finch.Generators.Npgsql.Tests;

public static class NpgsqlConnectionProvider
{
    public static NpgsqlConnection Create()
    {
        var connectionString = Constants.NpgsqlConnectionString;
        var connection = new NpgsqlConnection(connectionString);
        return connection;
    }
}