// Repositories/DishRepository.cs
using Microsoft.EntityFrameworkCore;
using MorgenstundRestaurant.Data;
using MorgenstundRestaurant.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IDishRepository
{
    // CREATE
    Task<Dish> AddAsync(Dish dish);

    // READ
    Task<Dish?> GetByIdAsync(int id);
    Task<IEnumerable<Dish>> GetAllAsync();

    // UPDATE
    Task UpdateAsync(Dish dish);

    // DELETE
    Task DeleteAsync(int id);
}

public class DishRepository : IDishRepository
{
    // CREATE
    public async Task<Dish> AddAsync(Dish dish)
    {
        using var context = new RestaurantDbContext();
        context.Dishes.Add(dish);
        await context.SaveChangesAsync();
        return dish;
    }

    // READ
    public async Task<Dish?> GetByIdAsync(int id)
    {
        using var context = new RestaurantDbContext();
        return await context.Dishes.FindAsync(id);
    }

    public async Task<IEnumerable<Dish>> GetAllAsync()
    {
        using var context = new RestaurantDbContext();
        return await context.Dishes.AsNoTracking().ToListAsync();
    }

    // UPDATE
    public async Task UpdateAsync(Dish dish)
    {
        using var context = new RestaurantDbContext();
        context.Entry(dish).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteAsync(int id)
    {
        using var context = new RestaurantDbContext();
        var dishToDelete = await context.Dishes.FindAsync(id);
        if (dishToDelete != null)
        {
            context.Dishes.Remove(dishToDelete);
            await context.SaveChangesAsync();
        }
    }
}