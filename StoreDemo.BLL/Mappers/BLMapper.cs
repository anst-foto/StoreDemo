namespace StoreDemo.BLL.Mappers;

public static class BLMapper
{
    public static BLL.Models.User MapUserDALToUserBLL(DAL.Models.User user)
    {
        return new BLL.Models.User()
        {
            Id = user.UserId,
            FullName = user.FullName
        };
    }
    public static DAL.Models.User MapUserBLLToUserDAL(BLL.Models.User user)
    {
        return new DAL.Models.User()
        {
            UserId = user.Id,
            FullName = user.FullName
        };
    }
    
    public static BLL.Models.Good MapGoodDALToGoodBLL(DAL.Models.Good good)
    {
        return new BLL.Models.Good()
        {
            Id = good.GoodId,
            Name = good.Name,
            Amount = good.Amount,
            Price = good.Price
        };
    }
    public static DAL.Models.Good MapGoodBLLToGoodDAL(BLL.Models.Good good)
    {
        return new DAL.Models.Good()
        {
            GoodId = good.Id,
            Name = good.Name,
            Amount = good.Amount,
            Price = good.Price
        };
    }

    public static BLL.Models.Sale MapSaleDALToSaleBLL(DAL.Models.Sale sale, IEnumerable<DAL.Models.User> users, IEnumerable<DAL.Models.Good> goods)
    {
        //BAD
        return new BLL.Models.Sale()
        {
            Id = sale.SaleId,
            Date = sale.Date,
            Good = MapGoodDALToGoodBLL(goods.First(g => g.GoodId == sale.GoodId)),
            User = MapUserDALToUserBLL(users.First(u => u.UserId == sale.UserId))
        };
    }
    public static DAL.Models.Sale MapSaleBLLToSaleDAL(BLL.Models.Sale sale)
    {
        //BAD
        return new DAL.Models.Sale()
        {
            SaleId = sale.Id,
            Date = sale.Date,
            GoodId = sale.Good.Id,
            UserId = sale.User.Id
        };
    }
}