using System.Data.SQLite;

namespace Finch.Generators.Sqlite.Tests;

public static class ConnectionProvider
{
    public static SQLiteConnection Create()
    {
        var connectionString = Finch.Tests.Shared.Constants.SqliteConnectionString;
        var connection = new SQLiteConnection(connectionString);
        return connection;
    }
}