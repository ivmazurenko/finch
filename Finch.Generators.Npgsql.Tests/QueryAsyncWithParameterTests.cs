using Npgsql;
using Xunit;

namespace Finch.Generators.Npgsql.Tests;

public class QueryAsyncWithParameterTests
{
    private readonly NpgsqlConnection _connection = NpgsqlConnectionProvider.Create();

    [Fact]
    public async Task QueriesSeriesAsInt()
    {
        var items = await _connection.QueryAsync<TbUser>(
            "select * from tb_user where id = @userId",
            default,
            new NpgsqlParameter { Value = 2, ParameterName = "userId" });

        Assert.Single(items);
        Assert.Equal(2, items.Single().id);
        Assert.Equal("Jane", items.Single().name);
    }
}