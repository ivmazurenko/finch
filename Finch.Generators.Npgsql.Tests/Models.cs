using Finch.Abstractions.Npgsql;

namespace Finch.Generators.Npgsql.Tests;

[GenerateNpgsqlConnectionExtensions]
public class TbUser
{
    public int id { get; set; }
    public string name { get; set; }
}

[GenerateNpgsqlConnectionExtensions]
public class TbValueVarchar100
{
    public string value { get; set; }
}

[GenerateNpgsqlConnectionExtensions]
public class TbValueBit
{
    public bool value { get; set; }
}

[GenerateNpgsqlConnectionExtensions]
public class TbValueBitNullable
{
    public bool? value { get; set; }
}