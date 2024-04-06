using MySql.Data.MySqlClient;
using Xunit;

namespace Finch.Generators.Mysql.Tests;

public class QueryAsyncTests
{
    private readonly MySqlConnection _connection = NpgsqlConnectionProvider.Create();

    [Fact]
    public async Task QueriesSeriesAsInt()
    {
        var items = await _connection.QueryAsync<TbUser>("select * from tb_user");

        Assert.Equal(2, items.Count);
        Assert.Equal(1, items[0].id);
        Assert.Equal(2, items[1].id);
        Assert.Equal("John", items[0].name);
        Assert.Equal("Jane", items[1].name);
    }

    [Fact]
    public async Task QueriesNullableBoolean()
    {
        var items = await _connection.QueryAsync<TbValueBitNullable>("select * from tb_value_bit_nullable");

        Assert.Equal(3, items.Count);
        Assert.Null(items[0].value);
        Assert.True(items[1].value);
        Assert.False(items[2].value);
    }

    [Fact]
    public async Task QueriesDifferentIntegersWithNulls()
    {
        var items =
            await _connection.QueryAsync<TbDifferentIntegerNullable>("select * from tb_different_integer_nullable");

        Assert.Equal(4, items.Count);
        Assert.Null(items[0].value_smallint);
        Assert.Equal(2, items[0].value_integer);
        Assert.Equal(4, items[0].value_bigint);

        Assert.Equal((short)1, items[1].value_smallint);
        Assert.Null(items[1].value_integer);
        Assert.Equal(4, items[1].value_bigint);

        Assert.Equal((short)1, items[2].value_smallint);
        Assert.Equal(2, items[2].value_integer);
        Assert.Null(items[2].value_bigint);


        Assert.Equal((short)0, items[3].value_smallint);
        Assert.Equal(0, items[3].value_integer);
        Assert.Equal(0, items[3].value_bigint);
    }
}