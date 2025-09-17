using Serilog;
using MorgenstundRestaurant.Entities;
using MorgenstundRestaurant.Exceptions;
using MorgenstundRestaurant.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenstundRestaurant.Services
{
    public interface IMenuService
    {
        Task<Menu> PrepareMenuAsync(int menuId);
    }

    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IDishService _dishService;

        public MenuService(IDishService dishService)
        {
            _menuRepository = new MenuRepository();
            _dishService = dishService;
        }

        public async Task<Menu> PrepareMenuAsync(int menuId)
        {
            var menuTemplate = await _menuRepository.GetByIdAsync(menuId)
                ?? throw new MenuPreparationException($"Menü-Vorlage mit ID {menuId} nicht gefunden.", new ArgumentNullException());

            Log.ForContext<MenuService>().Information("Beginne Zubereitung von '{MenuName}'...", menuTemplate.Name);

            try
            {
                var dishPreparationTasks = menuTemplate.Dishes.Select(dish => _dishService.PrepareDishAsync(dish.Id));
                var preparedDishes = await Task.WhenAll(dishPreparationTasks);

                var finalMenu = new Menu
                {
                    Id = menuTemplate.Id,
                    Name = menuTemplate.Name,
                    Dishes = preparedDishes.ToList()
                };

                Log.Information("Menü '{MenuName}' ist komplett. Preis: {Price}", finalMenu.Name, finalMenu.Price);
                return finalMenu;
            }
            catch (Exception ex) when (ex is DishNotFoundException || ex is OutOfStockException)
            {
                throw new MenuPreparationException($"Fehler bei der Zubereitung von Menü '{menuTemplate.Name}'.", ex);
            }
        }
    }
}
