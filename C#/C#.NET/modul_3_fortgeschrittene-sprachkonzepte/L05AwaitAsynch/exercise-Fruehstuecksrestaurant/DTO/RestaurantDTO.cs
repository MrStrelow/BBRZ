using System.Collections.Generic;
using System.Linq;

namespace MorgenstundRestaurant.DTOs;

public class RestaurantAnalyticsDto
{
    public int MostVisitedTable { get; set; }
    public Dictionary<string, int> MenuSales { get; set; } = new();
    public string MostPopularMenu => MenuSales.OrderByDescending(kv => kv.Value).FirstOrDefault().Key ?? "N/A";
}
