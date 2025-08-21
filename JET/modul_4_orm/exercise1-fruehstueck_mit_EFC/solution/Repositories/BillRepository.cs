using MorgenstundRestaurant.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Repositories;

public interface IBillRepository
{
    Task<IEnumerable<Bill>> GetAllAsync();
    Task<Bill?> GetByIdAsync(Guid id);
    Task AddAsync(Bill bill);
    Task SaveAllAsync(IEnumerable<Bill> bills);
}

public class BillRepository : IBillRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public BillRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "bills.json");
    }

    public async Task AddAsync(Bill bill)
    {
        await _fileLock.WaitAsync();
        try
        {
            var items = (await ReadFromFileAsync()).ToList();
            items.Add(bill);
            await WriteToFileAsync(items);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public async Task<IEnumerable<Bill>> GetAllAsync()
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

    public async Task<Bill?> GetByIdAsync(Guid id)
    {
        var bills = await GetAllAsync();
        return bills.FirstOrDefault(b => b.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Bill> bills)
    {
        await _fileLock.WaitAsync();
        try
        {
            await WriteToFileAsync(bills);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    private async Task<List<Bill>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Bill>();
        var json = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<Bill>();
        return JsonSerializer.Deserialize<List<Bill>>(json, _options) ?? new List<Bill>();
    }

    private async Task WriteToFileAsync(IEnumerable<Bill> bills)
    {
        var json = JsonSerializer.Serialize(bills, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}
