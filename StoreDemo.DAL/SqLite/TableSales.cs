using StoreDemo.DAL.Models;
using StoreDemo.DAL.Services;
using StoreDemo.DAL.Tables;

namespace StoreDemo.DAL.SqLite;

public class TableSales : ICrud<Sale>
{
    private readonly SqLiteService<Sale> _service;

    public TableSales()
    {
        _service = new SqLiteService<Sale>();
    }
    
    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
        var sales = await _service.GetAllAsync(tableName: TableNames.TABLE_SALES);
        return sales;
    }

    public async Task<Sale> GetByIdAsync(int id)
    {
        return await _service.FindWithNumberAsync(tableName:TableNames.TABLE_SALES, columnName:TableSalesColumns.ID, key:id);
    }

    public async Task InsertAsync(Sale obj)
    {
        var sql = $"""
                   INSERT INTO {TableNames.TABLE_SALES} ({TableSalesColumns.DATE}, {TableSalesColumns.GOOD_ID}, {TableSalesColumns.USER_ID})
                   VALUES ('{obj.Date}', {obj.GoodId}, {obj.UserId});
                   """;
        await _service.UpdateAndInsertAsync(sql);
    }

    public async Task UpdateAsync(Sale obj)
    {
        //FIXME 
    }
}