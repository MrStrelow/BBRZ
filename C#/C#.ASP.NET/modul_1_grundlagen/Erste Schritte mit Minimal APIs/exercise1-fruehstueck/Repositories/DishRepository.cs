using MorgenstundRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IDishRepository
{
    Task<IEnumerable<Dish>> GetAllAsync();
    Task<Dish?> GetByIdAsync(int id);
    Task SaveAllAsync(IEnumerable<Dish> dishes);
}

public class DishRepository : IDishRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public DishRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "dishes.json");
    }

    public async Task<IEnumerable<Dish>> GetAllAsync()
    {
        await _fileLock.WaitAsync();
        try
        {
            return await ReadFromFileAsync();
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public async Task<Dish?> GetByIdAsync(int id)
    {
        var dishes = await GetAllAsync();
        return dishes.FirstOrDefault(d => d.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Dish> dishes)
    {
        await _fileLock.WaitAsync();
        try
        {
            await WriteToFileAsync(dishes);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    private async Task<List<Dish>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Dish>();
        var json = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<Dish>();
        return JsonSerializer.Deserialize<List<Dish>>(json, _options) ?? new List<Dish>();
    }

    private async Task WriteToFileAsync(IEnumerable<Dish> dishes)
    {
        var json = JsonSerializer.Serialize(dishes, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
