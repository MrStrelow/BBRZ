using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Ticketverkauf.Entities;

namespace Ticketverkauf.Repositories;

public interface IBusRepository
{
    Task<IEnumerable<Bus>> GetAllAsync();
    Task<Bus?> GetByIdAsync(int id);
    Task SaveAllAsync(IEnumerable<Bus> busse);
}

public class BusRepository : IBusRepository
{
    private readonly string _filePath;
    private static readonly SemaphoreSlim _fileLock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true };

    public BusRepository()
    {
        var dataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        Directory.CreateDirectory(dataDirectory);
        _filePath = Path.Combine(dataDirectory, "busse.json");
    }

    public async Task<IEnumerable<Bus>> GetAllAsync()
    {
        await _fileLock.WaitAsync();
        try { return await ReadFromFileAsync(); }
        finally { _fileLock.Release(); }
    }

    public async Task<Bus?> GetByIdAsync(int id)
    {
        var busse = await GetAllAsync();
        return busse.FirstOrDefault(b => b.Id == id);
    }

    public async Task SaveAllAsync(IEnumerable<Bus> busse)
    {
        await _fileLock.WaitAsync();
        try { await WriteToFileAsync(busse); }
        finally { _fileLock.Release(); }
    }

    private async Task<List<Bus>> ReadFromFileAsync()
    {
        if (!File.Exists(_filePath)) return new List<Bus>();
        var json = await File.ReadAllTextAsync(_filePath);
        return string.IsNullOrWhiteSpace(json) ? new List<Bus>() : JsonSerializer.Deserialize<List<Bus>>(json, _options) ?? new List<Bus>();
    }

    private async Task WriteToFileAsync(IEnumerable<Bus> busse)
    {
        var json = JsonSerializer.Serialize(busse, _options);
        await File.WriteAllTextAsync(_filePath, json);
    }
}