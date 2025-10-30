namespace FruehstuecksBestellungMVC.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}