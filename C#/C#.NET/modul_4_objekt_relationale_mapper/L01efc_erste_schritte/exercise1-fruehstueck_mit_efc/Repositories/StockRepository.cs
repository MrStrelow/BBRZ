// Repositories/StockRepository.cs
using Microsoft.EntityFrameworkCore;
using MorgenstundRestaurant.Data;
using MorgenstundRestaurant.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IStockRepository
{
    // CREATE
    Task<StockItem> AddAsync(StockItem item);

    // READ
    Task<StockItem?> GetByIdAsync(int id);
    Task<IEnumerable<StockItem>> GetAllAsync();

    // UPDATE
    Task UpdateAsync(StockItem item);
    Task SaveAllAsync(IEnumerable<StockItem> items); // Behalten wir für den DishService

    // DELETE
    Task DeleteAsync(int id);
}

public class StockRepository : IStockRepository
{
    // CREATE
    public async Task<StockItem> AddAsync(StockItem item)
    {
        using var context = new RestaurantDbContext();
        context.Stock.Add(item);
        await context.SaveChangesAsync();
        return item;
    }

    // READ
    public async Task<StockItem?> GetByIdAsync(int id)
    {
        using var context = new RestaurantDbContext();
        return await context.Stock.FindAsync(id);
    }

    public async Task<IEnumerable<StockItem>> GetAllAsync()
    {
        using var context = new RestaurantDbContext();
        return await context.Stock.AsNoTracking().ToListAsync();
    }

    // UPDATE
    public async Task UpdateAsync(StockItem item)
    {
        using var context = new RestaurantDbContext();
        context.Entry(item).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task SaveAllAsync(IEnumerable<StockItem> items)
    {
        using var context = new RestaurantDbContext();
        context.Stock.UpdateRange(items);
        await context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteAsync(int id)
    {
        using var context = new RestaurantDbContext();
        var itemToDelete = await context.Stock.FindAsync(id);
        if (itemToDelete != null)
        {
            context.Stock.Remove(itemToDelete);
            await context.SaveChangesAsync();
        }
    }
}