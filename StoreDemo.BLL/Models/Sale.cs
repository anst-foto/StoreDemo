namespace StoreDemo.BLL.Models;

public record Sale
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }
    public Good Good { get; set; }
}