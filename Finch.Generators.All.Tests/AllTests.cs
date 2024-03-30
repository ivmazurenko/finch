using System.Data.SQLite;
using Finch.Tests.Shared;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Finch.Generators.All.Tests;

public class CanUseAllConnectionsAtTheSameTimeTests
{
    [Fact]
    public void SupportsClasses()
    {
        var connection1 = new NpgsqlConnection(Constants.NpgsqlConnectionString);
        var connection2 = new SqlConnection(Constants.SqlserverConnectionString);
        var connection3 = new SQLiteConnection(Constants.SqliteConnectionString);

        var res1 = connection1.Query<TbUserClass>("select * from tb_user limit 1").Single();
        var res2 = connection2.Query<TbUserClass>("select top 1 * from tb_user").Single();
        var res3 = connection3.Query<TbUserClass>("select * from tb_user limit 1").Single();

        Assert.Equal(res1.id, res2.id);
        Assert.Equal(res3.id, res2.id);
    }

    [Fact]
    public void SupportsRecords()
    {
        var connection1 = new NpgsqlConnection(Constants.NpgsqlConnectionString);
        var connection2 = new SqlConnection(Constants.SqlserverConnectionString);
        var connection3 = new SQLiteConnection(Constants.SqliteConnectionString);


        var res1 = connection1.Query<TbUserRecord>("select * from tb_user limit 1").Single();
        var res2 = connection2.Query<TbUserRecord>("select top 1 * from tb_user").Single();
        var res3 = connection3.Query<TbUserRecord>("select * from tb_user limit 1").Single();

        Assert.Equal(res1.id, res2.id);
        Assert.Equal(res3.id, res2.id);
    }
}