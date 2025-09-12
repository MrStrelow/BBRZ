using MorgenstundRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IStockRepository
{
    Task<IEnumerable<StockItem>> GetAllAsync();
    Task SaveAllAsync(IEnumerable<StockItem> items);
}

public class StockRepository : IStockRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public StockRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "stock.json");
    }

    public async Task<IEnumerable<StockItem>> GetAllAsync()
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

    public async Task SaveAllAsync(IEnumerable<StockItem> items)
    {
        await _fileLock.WaitAsync();
        try
        {
            await WriteToFileAsync(items);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    private async Task<List<StockItem>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<StockItem>();
        var json = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<StockItem>();
        return JsonSerializer.Deserialize<List<StockItem>>(json, _options) ?? new List<StockItem>();
    }

    private async Task WriteToFileAsync(IEnumerable<StockItem> items)
    {
        var json = JsonSerializer.Serialize(items, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
