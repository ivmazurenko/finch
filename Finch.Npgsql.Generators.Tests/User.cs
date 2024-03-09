using Finch.Npgsql.Abstractions;

namespace Finch.Npgsql.Generators.Tests;

[GenerateNpgsqlConnectionExtensions]
public class User
{
    public int id { get; set; }
    public string name { get; set; }
}