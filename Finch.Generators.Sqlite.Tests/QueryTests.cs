using System.Data.SQLite;
using Xunit;

namespace Finch.Generators.Sqlite.Tests;

public class QueryTests
{
    private readonly SQLiteConnection _connection = ConnectionProvider.Create();

    [Fact]
    public void QueriesSeriesAsInt()
    {
        var items = _connection.Query<TbUser>("select * from tb_user");

        Assert.Equal(2, items.Count);
        Assert.Equal(1, items[0].id);
        Assert.Equal(2, items[1].id);
    }

    [Fact]
    public void QueriesVarchar10AsString()
    {
        var items = _connection.Query<TbValueVarchar100>("select * from tb_value_varchar100");

        Assert.Equal(2, items.Count);
        Assert.Equal("John", items[0].value);
        Assert.Equal("Jane", items[1].value);
    }

    [Fact]
    public void QueriesBitAsBoolean()
    {
        var items = _connection.Query<TbValueBit>("select * from tb_value_bit");

        Assert.Equal(2, items.Count);
        Assert.False(items[0].value);
        Assert.True(items[1].value);
    }
}