using Microsoft.AspNetCore.Mvc.Rendering;
using FruehstuecksBestellungMVC.Models;
using FruehstuecksBestellungMVC.DTOs;

namespace FruehstuecksBestellungMVC.ViewModels;

public class FruehstueckViewModel
{
    // 1. Daten zur Anzeige (ersetzt das Tupel)
    public List<Menu> Menus { get; set; } = new();
    public List<Dish> Dishes { get; set; } = new();
    public List<Bill> Bills { get; set; } = new();
    public SelectList Customers { get; set; }
    public SelectList Tables { get; set; }

    // 2. Daten für den fehlerhaften Post-Request
    // Wir bündeln alle Formularfelder hier
    public CreateOrderDto OrderForm { get; set; } = new();
}