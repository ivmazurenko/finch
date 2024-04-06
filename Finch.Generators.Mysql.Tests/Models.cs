using Finch.Abstractions;

namespace Finch.Generators.Mysql.Tests;

[GenerateMysqlConnectionExtensions]
public class TbUser
{
    public int id { get; set; }
    public string name { get; set; }
}

[GenerateMysqlConnectionExtensions]
public class TbValueVarchar100
{
    public string value { get; set; }
}

[GenerateMysqlConnectionExtensions]
public class TbValueBit
{
    public bool value { get; set; }
}

[GenerateMysqlConnectionExtensions]
public class TbValueBitNullable
{
    public bool? value { get; set; }
}

[GenerateMysqlConnectionExtensions]
public class TbValueNumeric
{
    public decimal value { get; set; }
}

[GenerateMysqlConnectionExtensions]
public class TbDifferentIntegerNullable
{
    public short? value_smallint { get; set; }
    public int? value_integer { get; set; }
    public long? value_bigint { get; set; }
}

[GenerateMysqlConnectionExtensions]
public class TbValueNumericNullable
{
    public decimal? value { get; set; }
}