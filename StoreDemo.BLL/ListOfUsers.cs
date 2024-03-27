using StoreDemo.BLL.Models;
using StoreDemo.DAL;
using StoreDemo.DAL.SqLite;

namespace StoreDemo.BLL;

public class ListOfUsers
{
    private readonly ICrud<DAL.Models.User> _source;
    
    public List<User> Users { get; }

    public ListOfUsers()
    {
        _source = new TableUsers();
    }

    public async IAsyncEnumerable<User> GetAllAsync()
    {
        var result = await _source.GetAllAsync();
        foreach (var user in result)
        {
            yield return Mappers.BLMapper.MapUserDALToUserBLL(user);
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var result = await _source.GetByIdAsync(id);
        return Mappers.BLMapper.MapUserDALToUserBLL(result);
    }

    public async Task InsertAsync(User user)
    {
        await _source.InsertAsync(Mappers.BLMapper.MapUserBLLToUserDAL(user));
    }

    public async Task UpdateAsync(User user)
    {
        await _source.UpdateAsync(Mappers.BLMapper.MapUserBLLToUserDAL(user));
    }
}