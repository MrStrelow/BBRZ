using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public Task<IEnumerable<StockEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<StockEntity?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveAllAsync(IEnumerable<StockEntity> stocks)
    {
        throw new NotImplementedException();
    }
}
