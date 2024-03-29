namespace StoreDemo.WPF.Models;

public class User : BaseNotify
{
    private int _id;
    public int Id
    {
        get => _id;
        set => SetField(ref _id, value);
    }
    
    private string _name;
    public string FullName
    {
        get => _name; 
        set => SetField(ref _name, value);
    }
}