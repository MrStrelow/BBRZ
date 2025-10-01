namespace FruehstuecksBestellungMVC.Models;

public class Dish
{
    public int DishId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public int MenuId { get; set; }

    // kann. muss aber nicht! Wenn die Liste leer ist, dann ist es in keinem menü.
    // Ein Gericht kann in mehreren Deals/Menüs sein (n-m)
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public Order? Order { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public ICollection<PreparationStep> PreparationSteps { get; set; } = new List<PreparationStep>();
}