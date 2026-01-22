using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.Models;

public class Delivery
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public Order? Order { get; set; }
    public Customer? Customer { get; set; }
    public Bill? Bill { get; set; }

    // --- LIEFER DETAILS ---
    [Display(Name = "Erwartete Lieferzeit")]
    public DateTime? ExpectedDeliveryDate { get; set; }

    [Display(Name = "Tatsächliche Lieferzeit")]
    public DateTime? ActualDeliveryDate { get; set; }

    [Required]
    [RegularExpression(@"^[a-zA-Z0-9\s,.-]+$", ErrorMessage = "Die Adresse enthält ungültige Zeichen.")]
    public string DeliveryAddress { get; set; }

    [EmailAddress(ErrorMessage = "Keine gültige E-Mail-Adresse.")]
    public string? DeliveryEmail { get; set; }

    [Phone(ErrorMessage = "Keine gültige Telefonnummer.")]
    public string? DeliveryPhone { get; set; }
    public string? DeliveryComment { get; set; }
    public string? DeliveryImagePath { get; set; }
    public bool IsCanceled { get; set; }
}