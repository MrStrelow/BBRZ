using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels;

// Dieses ViewModel enthält die Daten, die vom Formular POST gesendet werden.
// Es implementiert IValidatableObject für Guards.
public class OrderViewModel : IValidatableObject
{
    private const string customerIsMissingErrorMessage = "Bitte wählen Sie einen Kunden aus.";
    
    [Required(ErrorMessage = customerIsMissingErrorMessage)]
    [Range(1, int.MaxValue, ErrorMessage = customerIsMissingErrorMessage)]
    [Display(Name = "Kunde")]
    public int? CustomerId { get; set; }

    private const string tableIsMissingErrorMessage = "Bitte wählen Sie einen Tisch aus.";

    [Required(ErrorMessage = tableIsMissingErrorMessage)]
    [Range(1, int.MaxValue, ErrorMessage = tableIsMissingErrorMessage)]
    [Display(Name = "Tisch Nr.")]
    public int? TableId { get; set; }

    public List<int> SelectedMenuIds { get; set; } = new();

    public List<int> SelectedDishIds { get; set; } = new();

    // Dies ist der Guard, der automatisch von ModelState.IsValid aufgerufen wird.
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (SelectedMenuIds.Count == 0 && SelectedDishIds.Count == 0)
        {
            // Das besprechen wir später. Wir merkenuns das yield return einfach fürs erste.
            yield return new ValidationResult(
                "Es muss mindestens ein Menü oder ein Gericht ausgewählt werden.",
                // Dieser Fehler wird im ValidationSummary angezeigt
                new[] { "OrderForm" } // Name der Eigenschaft im Haupt-ViewModel
            );
        }
    }
}