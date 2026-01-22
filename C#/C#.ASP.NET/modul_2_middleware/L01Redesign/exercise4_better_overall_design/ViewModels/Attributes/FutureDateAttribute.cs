using System.ComponentModel.DataAnnotations;

namespace FruehstuecksBestellungMVC.ViewModels.Attributes;

public class FutureDateAttribute : ValidationAttribute
{
    // Standard-Fehlermeldung, falls keine angegeben wird
    public FutureDateAttribute() : base("Das Datum muss in der Zukunft liegen.")
    {
    }

    public override bool IsValid(object? value)
    {
        // Null-Werte ignorieren wir hier. 
        // Ob ein Wert da sein MUSS, regelt das [Required] Attribut.
        if (value == null)
        {
            return true;
        }

        if (value is DateTime dateTime)
        {
            // Prüfung: Ist das Datum größer als Jetzt?
            // Optional: Ein paar Minuten Puffer erlauben, falls nötig
            return dateTime > DateTime.Now;
        }

        // Falls es kein DateTime ist, ist die Validierung technisch gesehen fehlgeschlagen (oder true, je nach Design)
        return false;
    }
}