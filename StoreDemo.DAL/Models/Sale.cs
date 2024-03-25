namespace StoreDemo.DAL.Models;

public class Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }
    public Good Good { get; set; }
}