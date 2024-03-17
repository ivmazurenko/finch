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