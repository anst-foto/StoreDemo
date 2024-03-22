using System.Text.Json;

namespace StoreDemo.DAL.DbConfig;

public class DbConfig
{
    public string? DataSource { get; set; }

    public override string ToString()
    {
        return DataSource is null ? "" : $"Data Source={DataSource}";
    }

    public static async Task<DbConfig?> GetFromConfigAsync(string path = "config.json")
    {
        await using var file = new FileStream(path, FileMode.Open, FileAccess.Read);
        var config = await JsonSerializer.DeserializeAsync<DbConfig>(file);
        return config;
    }
}