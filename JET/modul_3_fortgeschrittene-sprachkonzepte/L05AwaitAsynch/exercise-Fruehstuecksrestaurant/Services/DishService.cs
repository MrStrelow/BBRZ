// File: Services/DishService.cs
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Services;

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
        var dish = await _dishRepository.GetByIdAsync(dishId) ?? throw new ArgumentException($"Gericht mit ID {dishId} nicht gefunden.");

        Console.WriteLine($"  -> Beginne Zubereitung für: {dish.Name}");
        var stockItems = (await _stockRepository.GetAllAsync()).ToList();

        foreach (var ingredientName in dish.Ingredients)
        {
            var stockItem = stockItems.FirstOrDefault(s => s.Name.Equals(ingredientName, StringComparison.OrdinalIgnoreCase)) ?? throw new InvalidOperationException($"Zutat '{ingredientName}' nicht im Lager!");
            if (stockItem.Quantity <= 0) throw new InvalidOperationException($"Nicht genug von Zutat '{ingredientName}'!");

            stockItem.Quantity--;
        }

        await Task.Delay(50 + dish.PreparationSteps.Count * 50); // Simuliert die Zubereitungszeit
        await _stockRepository.SaveAllAsync(stockItems);

        Console.WriteLine($"  <- Gericht '{dish.Name}' ist fertig.");
        return dish;
    }
}