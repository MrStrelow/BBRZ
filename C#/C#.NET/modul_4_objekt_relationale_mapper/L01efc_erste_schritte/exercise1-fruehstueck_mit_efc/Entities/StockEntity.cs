using System.ComponentModel.DataAnnotations;

namespace MorgenstundRestaurant.Entities;

public class StockItem
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}