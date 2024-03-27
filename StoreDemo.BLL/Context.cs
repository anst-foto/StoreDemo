namespace StoreDemo.BLL;

public class Context
{
    public ListOfGoods Goods { get; }
    public ListOfUsers Users { get; }
    public ListOfSales Sales { get; }
    
    public Context()
    {
        Goods = new ListOfGoods();
        Users = new ListOfUsers();
        Sales = new ListOfSales();
    }
}