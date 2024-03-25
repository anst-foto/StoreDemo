using StoreDemo.DAL.Models;
using StoreDemo.DAL.Services;
using StoreDemo.DAL.Tables;

namespace StoreDemo.DAL.SqLite;

public class TableUsers : ICrud<User>
{
    private const string TABLE = TableNames.TABLE_USERS;
    private const string ID = TableUsersColumns.ID;
    private const string FULL_NAME = TableUsersColumns.FULL_NAME;
    
    private readonly SqLiteService<User> _service;

    public TableUsers()
    {
        _service = new SqLiteService<User>();
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _service.GetAllAsync(tableName:TABLE);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return await _service.FindWithNumberAsync(tableName:TABLE, columnName:ID, key:id);
    }

    public async Task InsertAsync(User obj)
    {
        var sql = $"INSERT INTO {TABLE} ({FULL_NAME}) VALUES ('{obj.FullName}')";
        await _service.UpdateAndInsertAsync(sql);
    }

    public async Task UpdateAsync(User obj)
    {
        var sql = $"UPDATE {TABLE} SET {FULL_NAME} = {obj.FullName} WHERE id = {obj.UserId}";
        await _service.UpdateAndInsertAsync(sql);
    }
}