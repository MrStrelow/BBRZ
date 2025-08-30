using Fahrradverleih.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Fahrradverleih.Repositories;

public interface IRechnungRepository
{
    Task<IEnumerable<Rechnung>> GetAllAsync();
    Task<Rechnung?> GetByIdAsync(Guid id);
    Task AddAsync(Rechnung rechnung);
    Task SaveAllAsync(IEnumerable<Rechnung> rechnungen);
}

public class RechnungRepository : IRechnungRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public RechnungRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "rechnungen.json");
    }

    public async Task AddAsync(Rechnung rechnung)
    {
        await _fileLock.WaitAsync();
        try
        {
            var items = (await ReadFromFileAsync()).ToList();
            items.Add(rechnung);
            await WriteToFileAsync(items);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    public async Task<IEnumerable<Rechnung>> GetAllAsync()
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

    public async Task<Rechnung?> GetByIdAsync(Guid id)
    {
        var rechnungen = await GetAllAsync();
        return rechnungen.FirstOrDefault(r => r.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Rechnung> rechnungen)
    {
        await _fileLock.WaitAsync();
        try
        {
            await WriteToFileAsync(rechnungen);
        }
        finally
        {
            _fileLock.Release();
        }
    }

    private async Task<List<Rechnung>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Rechnung>();
        var json = await File.ReadAllTextAsync(_filePath);
        if (string.IsNullOrWhiteSpace(json)) return new List<Rechnung>();
        return JsonSerializer.Deserialize<List<Rechnung>>(json, _options) ?? new List<Rechnung>();
    }

    private async Task WriteToFileAsync(IEnumerable<Rechnung> rechnungen)
    {
        var json = JsonSerializer.Serialize(rechnungen, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}