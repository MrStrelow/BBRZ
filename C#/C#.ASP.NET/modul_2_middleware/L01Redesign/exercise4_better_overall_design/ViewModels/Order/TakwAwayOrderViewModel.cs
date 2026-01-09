using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public class TakeAwayOrderViewModel : OrderViewModel
{
    [Required]
    public DateTime? PickupTime { get; set; }
}
