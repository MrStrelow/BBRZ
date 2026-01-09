using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public class TakeInOrderViewModel : OrderViewModel
{
    [Required(ErrorMessage = "Für Restaurantbesuche ist ein Tisch erforderlich.")]
    [Display(Name = "Tisch Nr.")]
    public int? TableId { get; set; }
}
