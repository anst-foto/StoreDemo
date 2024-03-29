namespace StoreDemo.DAL.Test;

public class DbConfigTest
{
    private const string Expected = "Data Source=store_demo.db";
    
    [Fact]
    public void DbConfigToStringTest()
    {
        var config = new DbConfig.DbConfig() { 
            DataSource = "store_demo.db"
        };
        var actual = config.ToString();

        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void GetFromConfigPositiveTest()
    {
        var config = DbConfig.DbConfig.GetFromConfig();
        var actual = config!.ToString();
        
        Assert.Equal(Expected, actual);
    }

    [Fact]
    public void GetFromConfigNegativeTest()
    {
        var config = DbConfig.DbConfig.GetFromConfig("bad_config.json");
        
        Assert.Null(config?.DataSource);
    }
}