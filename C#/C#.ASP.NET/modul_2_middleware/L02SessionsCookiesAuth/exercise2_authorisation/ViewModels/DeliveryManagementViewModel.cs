using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public class DeliveryManagementViewModel : IValidatableObject
{
    public int OrderId { get; set; }
    public int DeliveryId { get; set; }

    [Display(Name = "Kunde")]
    public string CustomerName { get; set; } = string.Empty;

    [Display(Name = "Bestelldatum")]
    public DateTime OrderDate { get; set; }

    [Display(Name = "Erwartetes Lieferdatum")]
    public DateTime? ExpectedDeliveryDate { get; set; }

    [Display(Name = "Tatsächliches Lieferdatum")]
    public DateTime? ActualDeliveryDate { get; set; }

    [Display(Name = "Kommentar")]
    public string? DeliveryComment { get; set; }

    [Display(Name = "Beweisfoto")]
    public IFormFile? DeliveryImage { get; set; }

    public string? ExistingImagePath { get; set; }

    public bool IsCanceled { get; set; }

    // Hilfseigenschaft für die UI-Logik (Storno Button anzeigen?)
    public bool CanBeCanceled => !ActualDeliveryDate.HasValue && !IsCanceled;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Validierung: Tatsächliches Lieferdatum darf nicht in der Zukunft liegen
        if (ActualDeliveryDate.HasValue && ActualDeliveryDate.Value > DateTime.Now)
        {
            yield return new ValidationResult("Das Lieferdatum darf nicht in der Zukunft liegen.", new[] { nameof(ActualDeliveryDate) });
        }

        // Bild-Validierung (nur simple Endungsprüfung wie gefordert)
        if (DeliveryImage != null)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var ext = Path.GetExtension(DeliveryImage.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(ext))
            {
                yield return new ValidationResult("Nur Bilddateien (.jpg, .png, .gif) sind erlaubt.", new[] { nameof(DeliveryImage) });
            }
        }
    }
}