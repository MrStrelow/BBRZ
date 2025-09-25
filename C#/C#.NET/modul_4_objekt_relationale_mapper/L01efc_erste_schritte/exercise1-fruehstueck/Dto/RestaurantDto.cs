namespace FruehstuecksrestaurantMore.DTOs;

public class RestaurantAnalyticsDto
{
    public int TableWithHighestRevenueId { get; set; }
    public decimal HighestRevenue { get; set; }
    public string MostPopularDish { get; set; }
}