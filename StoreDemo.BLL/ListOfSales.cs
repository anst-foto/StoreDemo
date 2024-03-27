using StoreDemo.BLL.Models;
using StoreDemo.DAL;
using StoreDemo.DAL.SqLite;

namespace StoreDemo.BLL;

public class ListOfSales
{
    private readonly ICrud<DAL.Models.Sale> _source;

    public ListOfSales()
    {
        _source = new TableSales();
    }

    public async IAsyncEnumerable<Sale> GetAllAsync()
    {
        var tableUsers = new TableUsers();
        var tableGoods = new TableGoods();

        var users = await tableUsers.GetAllAsync();
        var goods = await tableGoods.GetAllAsync();
        
        var result = await _source.GetAllAsync();
        foreach (var sale in result)
        {
            yield return Mappers.BLMapper.MapSaleDALToSaleBLL(sale, users, goods);
        }
    }

    public async Task<Sale> GetByIdAsync(int id)
    {
        var tableUsers = new TableUsers();
        var tableGoods = new TableGoods();

        var users = await tableUsers.GetAllAsync();
        var goods = await tableGoods.GetAllAsync();
        
        var result = await _source.GetByIdAsync(id);
        return Mappers.BLMapper.MapSaleDALToSaleBLL(result, users, goods);
    }

    public async Task InsertAsync(Sale sale)
    {
        await _source.InsertAsync(Mappers.BLMapper.MapSaleBLLToSaleDAL(sale));
    }
    
    public async Task UpdateAsync(Sale sale)
    {
        await _source.UpdateAsync(Mappers.BLMapper.MapSaleBLLToSaleDAL(sale));
    }
}