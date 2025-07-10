// File: Services/CustomerService.cs
using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Services;

public interface ICustomerService
{
    Task<Bill> PlaceOrderAsync(OrderDto order);
}

public class CustomerService : ICustomerService
{
    private readonly IBillRepository _billRepository;
    private readonly IMenuService _menuService;
    private const int MaxCustomersPerTable = 4;

    public CustomerService()
    {
        _billRepository = new BillRepository();
        _menuService = new MenuService();
    }

    public async Task<Bill> PlaceOrderAsync(OrderDto order)
    {
        if (order.CustomerOrders.Count > MaxCustomersPerTable)
            throw new InvalidOperationException($"Tisch {order.TableNumber} ist überbucht.");

        Console.WriteLine($"\n[Kunden-Service] Bestellung für Tisch {order.TableNumber} wird bearbeitet...");

        var menuPreparationTasks = order.CustomerOrders.Select(co => _menuService.PrepareMenuAsync(co.MenuId));
        var preparedMenus = await Task.WhenAll(menuPreparationTasks);

        var bill = new Bill
        {
            TableNumber = order.TableNumber,
            CustomerNames = order.CustomerOrders.Select(co => co.CustomerName).ToList(),
            OrderedMenus = preparedMenus.Select(m => m.Name).ToList(),
            TotalAmount = preparedMenus.Sum(m => m.Price),
        };

        await _billRepository.AddAsync(bill);

        Console.WriteLine($"[Kunden-Service] Rechnung für Tisch {order.TableNumber} erstellt. Betrag: {bill.TotalAmount:C}");
        return bill;
    }
}