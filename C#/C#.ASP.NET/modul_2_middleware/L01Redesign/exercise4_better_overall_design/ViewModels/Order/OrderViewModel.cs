using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public abstract class OrderViewModel
{
    // die CustomerId ist in jedem Fall (den wir uns gerade vorstellen können...) notwendig. 
    [Required(ErrorMessage = "Bitte wählen Sie einen Kunden aus.")]
    [Display(Name = "Kunde")]
    public int? CustomerId { get; set; }

    // Gemeinsame Listen für die Auswahl (Checkboxen)
    public List<int> SelectedMenuIds { get; set; } = new();
    public List<int> SelectedDishIds { get; set; } = new();
}
