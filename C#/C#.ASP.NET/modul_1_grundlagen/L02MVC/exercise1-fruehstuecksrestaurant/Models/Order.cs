namespace FruehstuecksBestellungMVC.Models;

public class Order
{
    public int OrderId { get; set; }
    public DateTime OrderTime { get; set; }

    public int VisitId { get; set; }
    public Visit? Visit { get; set; }

    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public int MenuId { get; set; }
    public ICollection<Menu> Menues { get; set; } = new List<Menu>();
}