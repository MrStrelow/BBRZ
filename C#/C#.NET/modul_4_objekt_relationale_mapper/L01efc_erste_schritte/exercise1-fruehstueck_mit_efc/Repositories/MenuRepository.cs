// Repositories/MenuRepository.cs
using Microsoft.EntityFrameworkCore;
using MorgenstundRestaurant.Data;
using MorgenstundRestaurant.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IMenuRepository
{
    // CREATE
    Task<Menu> AddAsync(Menu menu);

    // READ
    Task<Menu?> GetByIdAsync(int id);
    Task<IEnumerable<Menu>> GetAllAsync();

    // UPDATE
    Task UpdateAsync(Menu menu);

    // DELETE
    Task DeleteAsync(int id);
}

public class MenuRepository : IMenuRepository
{
    // CREATE
    public async Task<Menu> AddAsync(Menu menu)
    {
        using var context = new RestaurantDbContext();
        // Wichtig: Die 'Dishes' müssen vom Context getrackt werden, bevor wir sie hinzufügen.
        foreach (var dish in menu.Dishes)
        {
            context.Entry(dish).State = EntityState.Unchanged;
        }
        context.Menus.Add(menu);
        await context.SaveChangesAsync();
        return menu;
    }

    // READ
    public async Task<Menu?> GetByIdAsync(int id)
    {
        using var context = new RestaurantDbContext();
        return await context.Menus
            .Include(m => m.Dishes)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<IEnumerable<Menu>> GetAllAsync()
    {
        using var context = new RestaurantDbContext();
        return await context.Menus.Include(m => m.Dishes).AsNoTracking().ToListAsync();
    }

    // UPDATE
    public async Task UpdateAsync(Menu menu)
    {
        using var context = new RestaurantDbContext();

        var existingMenu = await context.Menus.Include(m => m.Dishes).FirstOrDefaultAsync(m => m.Id == menu.Id);
        if (existingMenu == null) return;

        // Aktualisiere einfache Eigenschaften
        context.Entry(existingMenu).CurrentValues.SetValues(menu);

        // Aktualisiere die n:m-Beziehung (Dishes)
        existingMenu.Dishes.Clear();
        var dishIds = menu.Dishes.Select(d => d.Id).ToList();
        var dishesFromDb = await context.Dishes.Where(d => dishIds.Contains(d.Id)).ToListAsync();
        foreach (var dish in dishesFromDb)
        {
            existingMenu.Dishes.Add(dish);
        }

        await context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteAsync(int id)
    {
        using var context = new RestaurantDbContext();
        var menuToDelete = await context.Menus.FindAsync(id);
        if (menuToDelete != null)
        {
            context.Menus.Remove(menuToDelete);
            await context.SaveChangesAsync();
        }
    }
}