using StoreDemo.BLL.Models;
using StoreDemo.DAL;
using StoreDemo.DAL.SqLite;

namespace StoreDemo.BLL;

public class ListOfGoods
{
    private readonly ICrud<DAL.Models.Good> _source;

    public ListOfGoods()
    {
        _source = new TableGoods();
    }
    
    public async IAsyncEnumerable<Good> GetAllAsync()
    {
        var result = await _source.GetAllAsync();
        foreach (var good in result)
        {
            yield return Mappers.BLMapper.MapGoodDALToGoodBLL(good);
        }
    }

    public async Task<Good> GetByIdAsync(int id)
    {
        var result = await _source.GetByIdAsync(id);
        return Mappers.BLMapper.MapGoodDALToGoodBLL(result);
    }

    public async Task InsertAsync(Good good)
    {
        await _source.InsertAsync(Mappers.BLMapper.MapGoodBLLToGoodDAL(good));
    }

    public async Task UpdateAsync(Good good)
    {
        await _source.UpdateAsync(Mappers.BLMapper.MapGoodBLLToGoodDAL(good));
    }
}