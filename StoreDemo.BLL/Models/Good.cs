namespace StoreDemo.BLL.Models;

public record Good
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public double Price { get; set; }
}