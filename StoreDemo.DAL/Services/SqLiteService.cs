using Dapper;
using Microsoft.Data.Sqlite;

namespace StoreDemo.DAL.Services;

public class SqLiteService<T>
{
    private readonly SqliteConnection _db;
    
    public SqLiteService(string configPath = "config.json")
    {
        var connectionString = DbConfig.DbConfig.GetFromConfig(configPath)?.ToString();
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException($"Проблема считывания конфига {configPath}");
        }

        _db = new SqliteConnection(connectionString);

        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string tableName)
    {
        await _db.OpenAsync();
        var sql = $"SELECT * FROM {tableName}";
        IEnumerable<T> result = await _db.QueryAsync<T>(sql);
        await _db.CloseAsync();

        return result;
    }

    public async Task<T> FindWithNumberAsync(string tableName, string columnName, int key)
    {
        await _db.OpenAsync();
        var sql = $"SELECT * FROM {tableName} WHERE {columnName} = {key}";
        T result = await _db.QuerySingleAsync<T>(sql);
        await _db.CloseAsync();

        return result;
    }

    public async Task UpdateAndInsertAsync(string sql)
    {
        await _db.OpenAsync();
        await _db.ExecuteAsync(sql);
        await _db.CloseAsync();
    }
}