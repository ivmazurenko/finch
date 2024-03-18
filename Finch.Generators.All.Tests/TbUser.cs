using Finch.Abstractions.Npgsql;
using Finch.Abstractions.Sqlite;
using Finch.Abstractions.Sqlserver;

namespace Finch.Generators.All.Tests;

[GenerateNpgsqlConnectionExtensions]
[GenerateSqliteConnectionExtensions]
[GenerateSqlserverConnectionExtensions]
public class TbUser
{
    public int id { get; set; }
    public string name { get; set; }
}