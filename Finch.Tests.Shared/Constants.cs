using Finch.Generators.Sqlite.Tests;

namespace Finch.Tests.Shared;

public static class Constants
{
    public static readonly string NpgsqlConnectionString =
        "Host=localhost;Port=5432;Username=sa;Password=vEryL111ngOassw1e!;Database=mock_database";

    public static readonly string SqliteConnectionString = $"Data Source={MockSqliteDatabasePath};Version=3;";

    public static readonly string SqlserverConnectionString =
        "Server=localhost,1433;User Id=SA;Password=vEryL111ngOassw1e!;Database=mock_database;Encrypt=false";

    private static string MockSqliteDatabasePath => Path.Combine(
        Solution.SolutionRootPath,
        "MockingDatabase",
        "mock_database_sqlite.db"
    );
}