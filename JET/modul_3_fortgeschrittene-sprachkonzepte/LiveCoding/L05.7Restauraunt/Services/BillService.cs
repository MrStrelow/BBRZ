using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.DTOs;
using Restauraunt.Entities;

namespace Restauraunt.Services;

public interface IBillService
{
    Task<Bill?> PlaceOrderAsync(TableOrderDto order);
}

internal class BillService : IBillService
{
    public async Task<Bill?> PlaceOrderAsync(TableOrderDto order)
    {
        throw new NotImplementedException();
    }
}
