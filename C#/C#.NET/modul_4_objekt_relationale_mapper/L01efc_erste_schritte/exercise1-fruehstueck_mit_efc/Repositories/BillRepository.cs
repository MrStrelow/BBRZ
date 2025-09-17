// Repositories/BillRepository.cs
using Microsoft.EntityFrameworkCore;
using MorgenstundRestaurant.Data;
using MorgenstundRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IBillRepository
{
    // CREATE
    Task AddAsync(Bill bill);

    // READ
    Task<Bill?> GetByIdAsync(Guid id);
    Task<IEnumerable<Bill>> GetAllAsync();
}

public class BillRepository : IBillRepository
{
    // CREATE
    public async Task AddAsync(Bill bill)
    {
        using var context = new RestaurantDbContext();
        context.Bills.Add(bill);
        await context.SaveChangesAsync();
    }

    // READ
    public async Task<Bill?> GetByIdAsync(Guid id)
    {
        using var context = new RestaurantDbContext();
        return await context.Bills.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Bill>> GetAllAsync()
    {
        using var context = new RestaurantDbContext();
        return await context.Bills.AsNoTracking().ToListAsync();
    }
}