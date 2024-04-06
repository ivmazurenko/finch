using Finch.Abstractions;

namespace Finch.Generators.Packages.Tests;

[GenerateNpgsqlConnectionExtensions]
[GenerateSqliteConnectionExtensions]
[GenerateSqlserverConnectionExtensions]
public class TbUserClass
{
    public int id { get; set; }
    public string name { get; set; }
}

[GenerateNpgsqlConnectionExtensions]
[GenerateSqliteConnectionExtensions]
[GenerateSqlserverConnectionExtensions]
public record TbUserRecord
{
    public int id { get; set; }
    public string name { get; set; }
}