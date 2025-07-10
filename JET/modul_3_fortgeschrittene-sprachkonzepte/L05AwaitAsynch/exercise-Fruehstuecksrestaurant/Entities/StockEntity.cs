namespace MorgenstundRestaurant.Entities;

/// <summary>
/// Repräsentiert eine Zutat im Lager.
/// </summary>
public class StockItem
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}
