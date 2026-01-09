using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public class DeliveryOrderViewModel : OrderViewModel
{
    [Required(ErrorMessage = "Adresse ist erforderlich.")]
    public string DeliveryAddress { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string DeliveryEmail { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string DeliveryPhone { get; set; } = string.Empty;

    [Required]
    [Date(ErrorMessage = "Lieferdatum muss in der Zukunft liegen.")] // Custom Attribute
    public DateTime? ExpectedDeliveryDate { get; set; }
}