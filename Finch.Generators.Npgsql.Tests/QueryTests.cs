using Npgsql;
using Xunit;

namespace Finch.Generators.Npgsql.Tests;

public class QueryTests
{
    private readonly NpgsqlConnection _connection = NpgsqlConnectionProvider.Create();

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

    [Fact]
    public void QueriesNullableBoolean()
    {
        var items = _connection.Query<TbValueBitNullable>("select * from tb_value_bit_nullable");

        Assert.Equal(3, items.Count);
        Assert.Null(items[0].value);
        Assert.True(items[1].value);
        Assert.False(items[2].value);
    }

    [Fact]
    public void QueriesDecimal()
    {
        var items = _connection.Query<TbValueNumeric>("select * from tb_value_numeric");

        Assert.Equal(2, items.Count);
        Assert.Equal(1.05m, items[0].value);
        Assert.Equal(1.99m, items[1].value);
    }

    [Fact]
    public void QueriesNullableDecimal()
    {
        var items = _connection.Query<TbValueNumericNullable>("select * from tb_value_numeric_nullable");

        Assert.Equal(2, items.Count);
        Assert.Null(items[0].value);
        Assert.Equal(1.22m, items[1].value);
    }
}