using System.Collections.Generic;

namespace MorgenstundRestaurant.DTOs;

public class TableOrderDto
{
    public int TableNumber { get; set; }
    public List<OrderDto> CustomerOrders { get; set; } = new();
}
