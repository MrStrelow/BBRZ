using Serilog;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Exceptions;
using MorgenstundRestaurant.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Services
{
    public interface IDishService
    {
        Task<Dish> PrepareDishAsync(int dishId);
    }

    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly IStockRepository _stockRepository;

        public DishService()
        {
            _dishRepository = new DishRepository();
            _stockRepository = new StockRepository();
        }

        public async Task<Dish> PrepareDishAsync(int dishId)
        {
            var dish = await _dishRepository.GetByIdAsync(dishId)
                ?? throw new DishNotFoundException($"Gericht mit ID {dishId} konnte nicht gefunden werden.");

            Log.ForContext<DishService>().Information("Beginne Zubereitung für: {DishName}", dish.Name);
            var stockItems = (await _stockRepository.GetAllAsync()).ToList();

            foreach (var ingredientName in dish.Ingredients)
            {
                var stockItem = stockItems.FirstOrDefault(s => s.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase));

                if (stockItem == null || stockItem.Quantity <= 0)
                {
                    throw new OutOfStockException($"Nicht genug von Zutat '{ingredientName}' für das Gericht '{dish.Name}' im Lager!");
                }

                stockItem.Quantity--;
            }

            await Task.Delay(50 + dish.PreparationSteps.Count * 50);
            await _stockRepository.SaveAllAsync(stockItems);

            Log.Information("Gericht '{DishName}' ist fertig.", dish.Name);
            return dish;
        }
    }
}
