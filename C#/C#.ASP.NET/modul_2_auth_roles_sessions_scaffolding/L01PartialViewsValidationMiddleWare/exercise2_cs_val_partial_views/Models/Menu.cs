namespace FruehstuecksBestellungMVC.Models;

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}