using System.Text.Json;

namespace StoreDemo.DAL.DbConfig;

public class DbConfig
{
    public string? DataSource { get; set; }

    public override string ToString()
    {
        return DataSource is null ? "" : $"Data Source={DataSource}";
    }

    public static DbConfig? GetFromConfig(string path = "config.json")
    {
        using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
        var config = JsonSerializer.Deserialize<DbConfig>(file);
        return config;
    }
}