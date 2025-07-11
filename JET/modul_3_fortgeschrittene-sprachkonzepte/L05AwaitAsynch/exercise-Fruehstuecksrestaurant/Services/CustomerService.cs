using MorgenstundRestaurant.DTOs;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Exceptions;
using MorgenstundRestaurant.Repositories;
using Serilog;

namespace MorgenstundRestaurant.Services
{
    public interface ICustomerService
    {
        Task<Bill> PlaceOrderAsync(OrderDto order);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IBillRepository _billRepository;
        private readonly IMenuService _menuService;
        private const int MaxCustomersPerTable = 4;

        public CustomerService(IMenuService menuService)
        {
            _billRepository = new BillRepository();
            _menuService = menuService;
        }

        public async Task<Bill> PlaceOrderAsync(OrderDto order)
        {
            if (order.CustomerOrders.Count > MaxCustomersPerTable)
                throw new InvalidOperationException($"Tisch {order.TableNumber} ist überbucht.");

            Log.ForContext<CustomerService>().Information("Bestellung für Tisch {TableNumber} wird bearbeitet...", order.TableNumber);

            try
            {
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
                Log.Information("Rechnung für Tisch {TableNumber} erstellt. Betrag: {TotalAmount}", bill.TableNumber, bill.TotalAmount);
                return bill;
            }
            catch (MenuPreparationException ex)
            {
                throw new OrderProcessingException($"Bestellung für Tisch {order.TableNumber} konnte nicht abgeschlossen werden.", ex);
            }
        }
    }
}
