using Npgsql;
using Xunit;

namespace Finch.Npgsql.Generators.Tests;

public class QueryTests
{
    private NpgsqlConnection _connection = NpgsqlConnectionProvider.Create();

    [Fact]
    public void QueriesSeriesAsInt()
    {
        var items = _connection.Query<User>("select * from tb_user");

        Assert.Equal(2, items.Count);
        Assert.Equal(1, items[0].id);
        Assert.Equal(2, items[1].id);
    }

    [Fact]
    public void QueriesVarchar10AsString()
    {
        var items = _connection.Query<User>("select * from tb_user");

        Assert.Equal(2, items.Count);
        Assert.Equal("John", items[0].name);
        Assert.Equal("Jane", items[1].name);
    }
}