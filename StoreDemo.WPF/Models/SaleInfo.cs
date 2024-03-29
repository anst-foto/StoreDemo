namespace StoreDemo.WPF.Models;

public class SaleInfo : BaseNotify
{
    private int _id;
    public int Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }

    private DateTime _date;
    public DateTime Date
    {
        get => _date; 
        set => SetField(ref _date, value);
    }
    
    private string _userName;
    public string UserName
    {
        get => _userName; 
        set => SetField(ref _userName, value);
    }
    
    private string _goodName;
    public string GoodName
    {
        get => _goodName; 
        set => SetField(ref _goodName, value);
    }

    private double _price;
    public double Price
    {
        get => _price;
        set => SetField(ref _price, value);
    }
}