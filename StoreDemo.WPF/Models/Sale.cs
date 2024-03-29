namespace StoreDemo.WPF.Models;

public class Sale : BaseNotify
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

    private User _user;
    public User User
    {
        get => _user;
        set => SetField(ref _user, value);
    }

    private Good _good;
    public Good Good
    {
        get => _good; 
        set => SetField(ref _good, value);
    }
}