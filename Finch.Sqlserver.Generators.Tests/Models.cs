using Finch.Sqlserver.Abstractions;

namespace Finch.Sqlserver.Generators.Tests;

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