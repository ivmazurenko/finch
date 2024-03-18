using System.Data.SQLite;

namespace Finch.Generators.Sqlite.Tests;

public static class ConnectionProvider
{
    public static SQLiteConnection Create()
    {
        var databasePath = Path.Combine(
            Solution.SolutionRootPath,
            "MockingDatabase",
            "mock_database_sqlite.db"
        );

        var connectionString = $"Data Source={databasePath};Version=3;";
        var connection = new SQLiteConnection(connectionString);
        return connection;
    }
}