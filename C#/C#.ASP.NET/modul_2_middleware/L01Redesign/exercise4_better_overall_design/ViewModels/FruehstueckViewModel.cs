using Microsoft.AspNetCore.Mvc.Rendering;
using FruehstuecksBestellungMVC.Models;

namespace FruehstuecksBestellungMVC.ViewModels;

public class FruehstueckViewModel
{
    // 1. Daten zur Anzeige (ersetzt das Tupel)
    public List<Menu> Menus { get; set; } = new();
    public List<Dish> Dishes { get; set; } = new();
    public SelectList Customers { get; set; }
    public SelectList Tables { get; set; }

    // Die spezifischen ViewModels für die Forms
    IOrderViewModel Order { get; set; }
    public TakeInOrderViewModel TakeInOrder { get; set; } = new();
    public DeliveryOrderViewModel DeliveryOrder { get; set; } = new();
    public TakeAwayOrderViewModel TakeAwayOrder { get; set; } = new();

    // getätigte bestellungen
    public List<Bill> Bills { get; set; } = new();
}