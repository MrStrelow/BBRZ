namespace FruehstuecksBestellungMVC.Models;

public class Menu
{
    public int MenuId { get; set; }
    public string Name { get; set; } = string.Empty; // z.B. "Schnitzel-Deal"
    public decimal Price { get; set; } // z.B. 10.00m

    // Ein Deal besteht aus mehreren Gerichten (n-m)
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    // Ein Deal kann oft bestellt werden (1-n)
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}