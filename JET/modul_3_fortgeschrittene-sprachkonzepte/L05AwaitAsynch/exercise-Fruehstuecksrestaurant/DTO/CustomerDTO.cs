namespace MorgenstundRestaurant.DTOs;
/// <summary>
/// DTO für die Bestellung eines einzelnen Kunden innerhalb einer Tischbestellung.
/// </summary>
public class CustomerOrderDto
{
    public string CustomerName { get; set; } = string.Empty;
    public int MenuId { get; set; }
}