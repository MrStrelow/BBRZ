using FruehstuecksBestellungMVC.Data;
using FruehstuecksBestellungMVC.DTOs;
using FruehstuecksBestellungMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FruehstuecksBestellungMVC.Services
{
    public class MenuService
    {
        private readonly ApplicationDbContext _dbContext;

        public MenuService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Menu> CreateMenu(MenuDto MenuDto)
        {
            var dishes = await _dbContext.Dishes.Where(d => MenuDto.DishIds.Contains(d.Id)).ToListAsync();

            var newMenu = new Menu
            {
                Name = MenuDto.Name,
                Price = dishes.Sum(x => x.Price)
            };

            _dbContext.Menus.Add(newMenu);
            await _dbContext.SaveChangesAsync();

            return newMenu;
        }
    }
}