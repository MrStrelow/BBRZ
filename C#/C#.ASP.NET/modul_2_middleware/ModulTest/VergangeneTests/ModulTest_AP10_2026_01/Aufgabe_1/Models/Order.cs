using Microsoft.AspNetCore.Identity;

namespace FruehstuecksBestellungMVC.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }

    public int? VisitId { get; set; }
    public Visit? Visit { get; set; }

    public int? DeliveryId { get; set; }
    public Delivery? Delivery { get; set; }

    public int? TakeAwayId { get; set; }
    public TakeAway? TakeAway { get; set; }

    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    public ICollection<Menu> Menus { get; set; } = new List<Menu>();
}