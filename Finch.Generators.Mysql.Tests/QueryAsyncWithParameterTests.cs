using MySql.Data.MySqlClient;
using Xunit;

namespace Finch.Generators.Mysql.Tests;

public class QueryAsyncWithParameterTests
{
    private readonly MySqlConnection _connection = NpgsqlConnectionProvider.Create();

    [Fact]
    public async Task QueriesSeriesAsInt()
    {
        var items = await _connection.QueryAsync<TbUser>(
            "select * from tb_user where id = @userId",
            default,
            new MySqlParameter { Value = 2, ParameterName = "userId" });

        Assert.Single(items);
        Assert.Equal(2, items.Single().id);
        Assert.Equal("Jane", items.Single().name);
    }
}