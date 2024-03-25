using StoreDemo.DAL.Models;
using StoreDemo.DAL.Services;
using StoreDemo.DAL.Tables;

namespace StoreDemo.DAL.Test;

public class SqLiteServiceTest
{
    private readonly List<User> _expectedUsers = new List<User>()
    {
        new User() {UserId = 1, FullName = "User 1"},
        new User() {UserId = 2, FullName = "User 2"},
        new User() {UserId = 3, FullName = "User 3"},
        new User() {UserId = 4, FullName = "User 4"},
        new User() {UserId = 5, FullName = "User 5"},
    };

    private SqLiteService<User> _service = new SqLiteService<User>();

    [Fact]
    public void CreateSqLiteServiceTestPositive()
    {
        Assert.NotNull(_service);
    }

    [Fact]
    public void CreateSqLiteServiceTestNegative()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            var _serviceNegative = new SqLiteService<User>("bad_config.json");
        });
    }
    
    [Fact]
    public async Task GetAllAsyncTest()
    {
        var actualUsers = await _service.GetAllAsync(TableNames.TABLE_USERS);
        Assert.Equal(_expectedUsers, actualUsers);
    }

    [Fact]
    public async Task FindWithNumberAsyncTest()
    {
        User expected = _expectedUsers[0];
        User actual = await _service.FindWithNumberAsync(TableNames.TABLE_USERS, TableUsersColumns.ID, 1);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task UpdateAndInsertAsyncTest()
    {
        _expectedUsers.Add(new User() {UserId = 6, FullName = "User II"});
        
        var sql = $"INSERT INTO {TableNames.TABLE_USERS} ({TableUsersColumns.FULL_NAME}) VALUES ('User II')";
        await _service.UpdateAndInsertAsync(sql);
        
        User actual = await _service.FindWithNumberAsync(TableNames.TABLE_USERS, TableUsersColumns.ID, 6);
        User expected = _expectedUsers[5];
        
        Assert.Equal(expected, actual);
    }
}