using FruehstuecksrestaurantMore.Data;
using FruehstuecksrestaurantMore.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FruehstuecksrestaurantMore.Services;

public class AnalyticsService
{
    private readonly RestaurantDbContext _context;

    // Der DbContext wird hier injiziert, anstatt eines Repositories.
    public AnalyticsService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<RestaurantAnalyticsDto> GetRestaurantAnalyticsAsync()
    {
        // Tisch mit dem meisten Umsatz finden
        var tableRevenue = await _context.Visits
            .Include(v => v.table)
            .Include(v => v.dishes)
            .GroupBy(v => v.table.Id) // Gruppiere alle Besuche nach Tisch-ID
            .Select(g => new
            {
                TableId = g.Key,
                // Summiere den Preis aller Gerichte für jeden Besuch in dieser Gruppe
                TotalRevenue = g.Sum(v => v.dishes.Sum(d => d.Price))
            })
            .OrderByDescending(x => x.TotalRevenue)
            .FirstOrDefaultAsync();

        // Beliebtestes Gericht finden
        var mostPopularDish = await _context.Visits
            .SelectMany(v => v.dishes) // Erstellt eine flache Liste aller bestellten Gerichte
            .GroupBy(d => d.Name)      // Gruppiert sie nach Namen
            .OrderByDescending(g => g.Count()) // Sortiert nach der Häufigkeit
            .Select(g => g.Key)        // Wählt den Namen des beliebtesten Gerichts
            .FirstOrDefaultAsync();


        if (tableRevenue is null)
        {
            return new RestaurantAnalyticsDto(); // Leeres DTO, wenn keine Daten da sind
        }

        return new RestaurantAnalyticsDto
        {
            TableWithHighestRevenueId = tableRevenue.TableId,
            HighestRevenue = tableRevenue.TotalRevenue,
            MostPopularDish = mostPopularDish ?? "N/A"
        };
    }
}