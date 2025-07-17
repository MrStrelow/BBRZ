using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Restauraunt.Entities;

namespace Restauraunt.Repositories;

public interface IStockRepository
{
    // CRUD: Read
    Task<IEnumerable<StockEntity>> GetAllAsync();
    Task<StockEntity?> GetByIdAsync(int id);

    // CRUD: Update
    Task SaveAllAsync(IEnumerable<StockEntity> stocks);
}

internal class JsonStockRespitory : IStockRepository
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly JsonSerializerOptions _options = new() { WriteIndented = true }

    public async Task<IEnumerable<StockEntity>> GetAllAsync()
    {
        var json = await File.ReadAllTextAsync("../../../stock.json");
        return JsonSerializer.Deserialize<List<StockEntity>>(json, _options) ?? new List<StockEntity>();
    }

    public Task<StockEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAllAsync(IEnumerable<StockEntity> stocks)
    {
        var json = JsonSerializer.Serialize(stocks, _options);

        await _lock.WaitAsync();
        try
        {
            await File.WriteAllTextAsync("../../../stock.json", json);
        }
        finally
        {
            _lock.Release();
        }
    }
}
