namespace StoreDemo.DAL.Models;

public class Good
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; } //TODO добавить валидицию
    public double Price { get; set; } //TODO добавить валидицию
}