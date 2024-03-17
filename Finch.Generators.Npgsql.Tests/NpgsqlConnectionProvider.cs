using Npgsql;

namespace Finch.Npgsql.Generators.Tests;

public static class NpgsqlConnectionProvider
{
    public static NpgsqlConnection Create()
    {
        const string connectionString =
            "Host=localhost;Port=5432;Username=sa;Password=sa_pass_111;Database=mock_database";
        var connection = new NpgsqlConnection(connectionString);
        return connection;
    }
}