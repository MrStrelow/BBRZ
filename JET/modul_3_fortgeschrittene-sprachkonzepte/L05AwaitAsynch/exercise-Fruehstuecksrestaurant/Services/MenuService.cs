// File: Services/MenuService.cs
using MorgenstundRestaurant.Entities;
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

        public MenuService()
        {
            _menuRepository = new MenuRepository();
            _dishService = new DishService();
        }

        public async Task<Menu> PrepareMenuAsync(int menuId)
        {
            var menuTemplate = await _menuRepository.GetByIdAsync(menuId) ?? throw new ArgumentException($"Menü mit ID {menuId} nicht gefunden.");

            Console.WriteLine($"[Menü-Service] Beginne Zubereitung von '{menuTemplate.Name}'...");

            var dishPreparationTasks = menuTemplate.DishIds.Select(dishId => _dishService.PrepareDishAsync(dishId));
            var preparedDishes = await Task.WhenAll(dishPreparationTasks);

            var finalMenu = new Menu
            {
                Id = menuTemplate.Id,
                Name = menuTemplate.Name,
                DishIds = menuTemplate.DishIds,
                Dishes = preparedDishes.ToList()
            };

            Console.WriteLine($"[Menü-Service] Menü '{finalMenu.Name}' ist komplett. Preis: {finalMenu.Price:C}");
            return finalMenu;
        }
    }
}