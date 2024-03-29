namespace StoreDemo.WPF.Models;

public class Good : BaseNotify
{
    private int _id;
    public int Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }

    private string _name;
    public string Name
    {
        get => _name; 
        set => SetField(ref _name, value);
    }

    private int _amount;
    public int Amount
    {
        get => _amount;
        set => SetField(ref _amount, value);
    }

    private double _price;
    public double Price
    {
        get => _price;
        set => SetField(ref _price, value);
    }
}