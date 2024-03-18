using Finch.Abstractions.Sqlserver;

namespace Finch.Generators.Sqlserver.Tests;

[GenerateSqlserverConnectionExtensions]
public class TbUser
{
    public int id { get; set; }
    public string name { get; set; }
}

[GenerateSqlserverConnectionExtensions]
public class TbValueVarchar100
{
    public string value { get; set; }
}

[GenerateSqlserverConnectionExtensions]
public class TbValueBit
{
    public bool value { get; set; }
}

[GenerateSqlserverConnectionExtensions]
public class TbValueBitNullable
{
    public bool? value { get; set; }
}

[GenerateSqlserverConnectionExtensions]
public class TbDifferentIntegerNullable
{
    public short? value_smallint { get; set; }
    public int? value_integer { get; set; }
    public long? value_bigint { get; set; }
}