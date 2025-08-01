﻿using Restauraunt.Entities;
using Restauraunt.Repositories;
using Restauraunt.Services.Exceptions;

namespace Restauraunt.Services;

public interface IDishService
{
    Task<Dish> PrepareDishAsync(int dishId);
}

internal class DishService : IDishService
{
    private readonly IDishRepository _dishRespitory = new JsonDishRespitory();
    private readonly IStockRepository _stockRepository = new JsonStockRespitory();

    public async Task<Dish> PrepareDishAsync(int dishId)
    {
        // Repitiory Call: Read
        // und Exception handling
        var dish = await _dishRespitory.GetByIdAsync(dishId) 
            ?? throw new DishNotFoundException($"Gericht mit ID {dishId} konnte nicht gefunden werden.");

        // Service/Businesa Logic
        var stocks = (await _stockRepository.GetAllAsync()).ToList();

        foreach (var ingredient in dish.Ingredients)
        {
            var stock = stocks.FirstOrDefault(s => s.Name.Equals(ingredient));

            stock.Quantity--;

            // wir kochen hier...
        }

        // Repository Call: Update
        await _stockRepository.SaveAllAsync(stocks);


        return dish;
    }
}
