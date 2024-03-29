using StoreDemo.WPF.Models;

namespace StoreDemo.WPF.Mappers;

public static class UIMapper
{
    public static WPF.Models.User MapperBLLUserToUIUser(BLL.Models.User user)
    {
        return new WPF.Models.User()
        {
            Id = user.Id,
            FullName = user.FullName
        };
    }
    
    public static BLL.Models.User MapperUIUserToBLLUser(WPF.Models.User user)
    {
        return new BLL.Models.User()
        {
            Id = user.Id,
            FullName = user.FullName
        };
    }
    
    public static WPF.Models.Good MapperBLLGoodToUIGood(BLL.Models.Good good)
    {
        return new WPF.Models.Good()
        {
            Id = good.Id,
            Name = good.Name,
            Amount = good.Amount,
            Price = good.Price
        };
    }
    
    public static BLL.Models.Good MapperUIGoodToBLLGood(WPF.Models.Good good)
    {
        return new BLL.Models.Good()
        {
            Id = good.Id,
            Name = good.Name,
            Amount = good.Amount,
            Price = good.Price
        };
    }
    
    public static WPF.Models.Sale MapperBLLSaleToUISale(BLL.Models.Sale sale)
    {
        return new WPF.Models.Sale()
        {
            Id = sale.Id,
            Date = sale.Date,
            User = MapperBLLUserToUIUser(sale.User),
            Good = MapperBLLGoodToUIGood(sale.Good)
        };
    }
    
    public static BLL.Models.Sale MapperUISaleToBLLSale(WPF.Models.Sale sale)
    {
        return new BLL.Models.Sale()
        {
            Id = sale.Id,
            Date = sale.Date,
            User = MapperUIUserToBLLUser(sale.User),
            Good = MapperUIGoodToBLLGood(sale.Good)
        };
    }

    public static WPF.Models.SaleInfo MapperBllSaleToUISaleInfo(BLL.Models.Sale sale)
    {
        return new SaleInfo()
        {
            Id = sale.Id,
            Date = sale.Date,
            UserName = sale.User.FullName,
            GoodName = sale.Good.Name,
            Price = sale.Good.Price
        };
    }
}