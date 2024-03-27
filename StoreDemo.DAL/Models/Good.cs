namespace StoreDemo.DAL.Models;

public record Good
{
    public int GoodId { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; } //TODO добавить валидицию
    public double Price { get; set; } //TODO добавить валидицию
}