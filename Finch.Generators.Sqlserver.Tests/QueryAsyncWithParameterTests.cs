using Microsoft.Data.SqlClient;
using Xunit;

namespace Finch.Generators.Sqlserver.Tests;

public class QueryAsyncWithParameterTests
{
    private readonly SqlConnection _connection = SqlConnectionProvider.Create();

    [Fact]
    public async Task QueriesSeriesAsInt()
    {
        var items = await _connection.QueryAsync<TbUser>(
            "select * from tb_user where id = @userId",
            default,
            new SqlParameter { Value = 2, ParameterName = "userId" });

        Assert.Single(items);
        Assert.Equal(2, items.Single().id);
        Assert.Equal("Jane", items.Single().name);
    }
}