using System.Data.SQLite;
using Xunit;

namespace Finch.Generators.Sqlite.Tests;

public class QueryAsyncWithParameterTests
{
    private readonly SQLiteConnection _connection = ConnectionProvider.Create();

    [Fact]
    public async Task QueriesSeriesAsInt()
    {
        var items = await _connection.QueryAsync<TbUser>(
            "select * from tb_user where id = @userId",
            default,
            new SQLiteParameter { Value = 2, ParameterName = "userId" });

        Assert.Single(items);
        Assert.Equal(2, items.Single().id);
        Assert.Equal("Jane", items.Single().name);
    }
}