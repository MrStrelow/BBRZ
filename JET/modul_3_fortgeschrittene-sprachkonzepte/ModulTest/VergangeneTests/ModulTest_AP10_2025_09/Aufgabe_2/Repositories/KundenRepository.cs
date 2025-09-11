using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ticketverkauf.Entities;

namespace Ticketverkauf.Repositories;

public interface IKundenRepository
{
    Task<IEnumerable<Kunde>> GetAllAsync();
    Task<Kunde?> GetByIdAsync(int id);
    Task SaveAllAsync(IEnumerable<Kunde> kunden);
}

public class KundenRepository : IKundenRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public KundenRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "kunden.json");
    }

    public async Task<IEnumerable<Kunde>> GetAllAsync()
    {
        await _fileLock.WaitAsync();
        try { return await ReadFromFileAsync(); }
        finally { _fileLock.Release(); }
    }

    public async Task<Kunde?> GetByIdAsync(int id)
    {
        var kunden = await GetAllAsync();
        return kunden.FirstOrDefault(k => k.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Kunde> kunden)
    {
        await _fileLock.WaitAsync();
        try { await WriteToFileAsync(kunden); }
        finally { _fileLock.Release(); }
    }

    private async Task<List<Kunde>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Kunde>();
        var json = await File.ReadAllTextAsync(_filePath);
        return string.IsNullOrWhiteSpace(json) ? new List<Kunde>() : JsonSerializer.Deserialize<List<Kunde>>(json, _options) ?? new List<Kunde>();
    }

    private async Task WriteToFileAsync(IEnumerable<Kunde> kunden)
    {
        var json = JsonSerializer.Serialize(kunden, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}