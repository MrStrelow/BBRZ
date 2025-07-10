using System.Collections.Generic;

namespace MorgenstundRestaurant.DTOs;

/// <summary>
/// DTO zum Aufgeben einer Bestellung für einen ganzen Tisch.
/// </summary>
public class OrderDto
{
    public int TableNumber { get; set; }
    public List<CustomerOrderDto> CustomerOrders { get; set; } = new();
}
