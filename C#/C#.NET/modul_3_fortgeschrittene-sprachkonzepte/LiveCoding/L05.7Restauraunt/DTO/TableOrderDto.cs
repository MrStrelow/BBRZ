using Restaurant.DTOs;
using System.Collections.Generic;

namespace Restaurant.DTOs;

public record TableOrderDto(
    int TableNumber, 
    List<OrderDto> CustomerOrders
);