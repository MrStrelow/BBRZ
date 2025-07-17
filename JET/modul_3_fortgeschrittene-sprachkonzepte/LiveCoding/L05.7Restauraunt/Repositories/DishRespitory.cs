using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Restauraunt.Entities;

namespace Restauraunt.Repositories;

public interface IDishRepository
{
    // CRUD: Read
    Task<IEnumerable<Dish>> GetAllAsync();
    Task<Dish?> GetByIdAsync(int id);

    // CRUD: Update
    Task SaveAllAsync(IEnumerable<Dish> dishes);
}

internal class JsonDishRespitory : IDishRepository
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true }

    public async Task<IEnumerable<Dish>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Dish?> GetByIdAsync(int id)
    {
        var json = await File.ReadAllTextAsync("../../../dishes.json");
        return JsonSerializer.Deserialize<List<Dish>>(json, _options)?.FirstOrDefault(dish => dish.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Dish> dishes)
    {
        var json = JsonSerializer.Serialize(dishes, _options);

        await _lock.WaitAsync();
        try
        {
            await File.WriteAllTextAsync("../../../dishes.json", json);
        }
        finally
        {
            _lock.Release();
        }
    }
}
