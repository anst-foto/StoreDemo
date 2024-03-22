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
    public async Task GetFromConfigAsyncPositiveTest()
    {
        var config = await DbConfig.DbConfig.GetFromConfigAsync();
        var actual = config!.ToString();
        
        Assert.Equal(Expected, actual);
    }

    [Fact]
    public async Task GetFromConfigAsyncNegativeTest()
    {
        var config = await DbConfig.DbConfig.GetFromConfigAsync("bad_config.json");
        
        Assert.Null(config?.DataSource);
    }
}