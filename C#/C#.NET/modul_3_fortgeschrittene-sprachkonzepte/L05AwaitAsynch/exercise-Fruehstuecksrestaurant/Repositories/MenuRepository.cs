using MorgenstundRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IMenuRepository
{
    Task<IEnumerable<Menu>> GetAllAsync();
    Task<Menu?> GetByIdAsync(int id);
    Task SaveAllAsync(IEnumerable<Menu> menus);
}

public class MenuRepository : IMenuRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public MenuRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "menus.json");
    }

    public async Task<IEnumerable<Menu>> GetAllAsync()
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

    public async Task<Menu?> GetByIdAsync(int id)
    {
        var menus = await GetAllAsync();
        return menus.FirstOrDefault(m => m.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Menu> menus)
    {
        await _fileLock.WaitAsync();
        try
        {
            await WriteToFileAsync(menus);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    private async Task<List<Menu>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Menu>();
        var json = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<Menu>();
        return JsonSerializer.Deserialize<List<Menu>>(json, _options) ?? new List<Menu>();
    }

    private async Task WriteToFileAsync(IEnumerable<Menu> menus)
    {
        var json = JsonSerializer.Serialize(menus, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
