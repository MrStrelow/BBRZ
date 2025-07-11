using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public Task<IEnumerable<Dish>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Dish?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task SaveAllAsync(IEnumerable<Dish> dishes)
    {
        throw new NotImplementedException();
    }
}
