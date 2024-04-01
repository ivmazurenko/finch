using Finch.Abstractions.Sqlite;

namespace Finch.Generators.Sqlite.Tests;

[GenerateSqliteConnectionExtensions]
public class TbUser
{
    public int id { get; set; }
    public string name { get; set; }
}

[GenerateSqliteConnectionExtensions]
public class TbValueVarchar100
{
    public string value { get; set; }
}

[GenerateSqliteConnectionExtensions]
public class TbValueBit
{
    public bool value { get; set; }
}

[GenerateSqliteConnectionExtensions]
public class TbValueBitNullable
{
    public bool? value { get; set; }
}

[GenerateSqliteConnectionExtensions]
public class TbDifferentIntegerNullable
{
    public short? value_smallint { get; set; }
    public int? value_integer { get; set; }
    public long? value_bigint { get; set; }
}

[GenerateSqliteConnectionExtensions]
public class TbValueNumeric
{
    public decimal value { get; set; }
}