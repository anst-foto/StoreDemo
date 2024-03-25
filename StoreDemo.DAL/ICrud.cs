using StoreDemo.DAL.Models;

namespace StoreDemo.DAL;

public interface ICrud<T>
{
    public Task<IEnumerable<User>> GetAllAsync();
    public Task<T> GetByIdAsync(int id);

    public Task InsertAsync(T obj);

    public Task UpdateAsync(T obj);
}