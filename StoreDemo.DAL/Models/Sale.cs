namespace StoreDemo.DAL.Models;

public record Sale
{
    public int SaleId { get; set; }
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public int GoodId { get; set; }
}