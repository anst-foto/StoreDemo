using StoreDemo.DAL.Models;
using StoreDemo.DAL.Services;
using StoreDemo.DAL.Tables;

namespace StoreDemo.DAL.SqLite;

public class TableGoods : ICrud<Good>
{
    private readonly SqLiteService<Good> _service;

    public TableGoods()
    {
        _service = new SqLiteService<Good>();
    }
    
    public async Task<IEnumerable<Good>> GetAllAsync()
    {
        return await _service.GetAllAsync(tableName:TableNames.TABLE_GOODS);
    }

    public async Task<Good> GetByIdAsync(int id)
    {
        return await _service.FindWithNumberAsync(tableName:TableNames.TABLE_GOODS, columnName:TableGoodsColumns.ID, key:id);
    }

    public async Task InsertAsync(Good obj)
    {
        var sql = $"""
                   INSERT INTO {TableNames.TABLE_GOODS} ({TableGoodsColumns.NAME}, {TableGoodsColumns.AMOUNT}, {TableGoodsColumns.PRICE}) 
                   VALUES ('{obj.Name}', {obj.Amount}, {obj.Price});
                   """;
        await _service.UpdateAndInsertAsync(sql);
    }

    public async Task UpdateAsync(Good obj)
    {
        var sql = $"""
                   UPDATE {TableNames.TABLE_GOODS}
                   SET {TableGoodsColumns.NAME} = {obj.Name},
                       {TableGoodsColumns.AMOUNT} = {obj.Amount},
                       {TableGoodsColumns.PRICE} = {obj.Price}
                   WHERE id = {obj.GoodId};
                   """;
        await _service.UpdateAndInsertAsync(sql);
    }
}