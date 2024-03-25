using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDemo.DAL.Models;

public record User
{
    public int UserId { get; set; }
    public string FullName { get; set; }
}