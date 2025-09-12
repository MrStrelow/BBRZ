using Serilog;
using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Services
{
    public interface IAnalyticsService
    {
        Task<RestaurantAnalyticsDto> GetRestaurantAnalyticsAsync();
    }

    public class AnalyticsService : IAnalyticsService
    {
        private readonly IBillRepository _billRepository;

        public AnalyticsService()
        {
            _billRepository = new BillRepository();
        }

        public async Task<RestaurantAnalyticsDto> GetRestaurantAnalyticsAsync()
        {
            Log.ForContext<AnalyticsService>().Information("Starte Restaurant-Analyse...");
            var bills = await _billRepository.GetAllAsync();
            if (!bills.Any())
            {
                Log.Warning("Keine Rechnungen für die Analyse gefunden.");
                return new RestaurantAnalyticsDto { MostVisitedTable = 0 };
            }

            var mostVisitedTable = bills
                .GroupBy(b => b.TableNumber)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key)
                .FirstOrDefault();

            var menuSales = bills
                .SelectMany(b => b.OrderedMenus)
                .GroupBy(menuName => menuName)
                .ToDictionary(g => g.Key, g => g.Count());

            var analytics = new RestaurantAnalyticsDto
            {
                MostVisitedTable = mostVisitedTable,
                MenuSales = menuSales
            };

            Log.Information("Analyse abgeschlossen.");
            return analytics;
        }
    }
}
