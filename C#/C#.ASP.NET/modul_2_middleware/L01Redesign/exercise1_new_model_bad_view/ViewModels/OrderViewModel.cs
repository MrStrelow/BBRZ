using FruehstuecksBestellungMVC.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

public class OrderViewModel : IValidatableObject
{
    [Display(Name = "Bestellart")]
    public OrderType Type { get; set; } = OrderType.TakeIn;

    private const string customerIsMissingErrorMessage = "Bitte wählen Sie einen Kunden aus.";

    [Required(ErrorMessage = customerIsMissingErrorMessage)]
    [Display(Name = "Kunde")]
    public int? CustomerId { get; set; }

    [Display(Name = "Tisch Nr.")]
    public int? TableId { get; set; }

    // --- Lieferinformationen ---
    [Display(Name = "Adresse")]
    // Regex: Erlaubt Buchstaben, Punkte, Bindestriche, Leerzeichen und muss mit einer Zahl enden (Hausnummer)
    [RegularExpression(@"^[a-zA-ZäöüÄÖÜß\s\.\-]+\s\d+[a-zA-Z]?$", ErrorMessage = "Bitte geben Sie eine gültige Adresse mit Hausnummer an.")]
    public string? DeliveryAddress { get; set; }

    [Display(Name = "E-Mail")]
    [EmailAddress(ErrorMessage = "Ungültige E-Mail-Adresse.")]
    public string? DeliveryEmail { get; set; }

    [Display(Name = "Telefonnummer")]
    [Phone(ErrorMessage = "Ungültige Telefonnummer.")]
    public string? DeliveryPhone { get; set; }

    [Display(Name = "Erwartetes Lieferdatum")]
    public DateTime? ExpectedDeliveryDate { get; set; }

    public List<int> SelectedMenuIds { get; set; } = new();
    public List<int> SelectedDishIds { get; set; } = new();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Guard 1: Mindestens ein Gericht/Menü
        if (SelectedMenuIds.Count == 0 && SelectedDishIds.Count == 0)
        {
            yield return new ValidationResult(
                "Es muss mindestens ein Menü oder ein Gericht ausgewählt werden.",
                new[] { nameof(SelectedMenuIds) }
            );
        }

        // Guard 2: Bedingte Pflichtfelder je nach Typ
        if (Type == OrderType.TakeIn)
        {
            if (!TableId.HasValue)
            {
                yield return new ValidationResult("Für Restaurantbesuche ist ein Tisch erforderlich.", new[] { nameof(TableId) });
            }
        }
        else if (Type == OrderType.Delivery)
        {
            if (string.IsNullOrWhiteSpace(DeliveryAddress))
                yield return new ValidationResult("Adresse ist erforderlich.", new[] { nameof(DeliveryAddress) });

            if (string.IsNullOrWhiteSpace(DeliveryEmail))
                yield return new ValidationResult("E-Mail ist erforderlich.", new[] { nameof(DeliveryEmail) });

            if (string.IsNullOrWhiteSpace(DeliveryPhone))
                yield return new ValidationResult("Telefonnummer ist erforderlich.", new[] { nameof(DeliveryPhone) });

            if (!ExpectedDeliveryDate.HasValue)
                yield return new ValidationResult("Erwartetes Lieferdatum ist erforderlich.", new[] { nameof(ExpectedDeliveryDate) });

            // Logik: Erwartetes Lieferdatum darf nicht in der Vergangenheit liegen (z.B. vor 5 Minuten)
            if (ExpectedDeliveryDate.HasValue && ExpectedDeliveryDate.Value < DateTime.Now.AddMinutes(-5))
            {
                yield return new ValidationResult("Das Lieferdatum kann nicht in der Vergangenheit liegen.", new[] { nameof(ExpectedDeliveryDate) });
            }
        }
    }
}