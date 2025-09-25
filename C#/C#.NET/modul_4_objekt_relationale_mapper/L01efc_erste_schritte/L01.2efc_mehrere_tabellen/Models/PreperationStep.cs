// Repräsentiert einen einzelnen Zubereitungsschritt.
using System.ComponentModel.DataAnnotations.Schema;

namespace FruehstuecksrestaurantMore.Models;

public class PreparationStep
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instruction { get; set; }

    // Wir wollen den Fremdschlüssel nicht im Model haben, da es Konzeptionell nicht hier dazupasst.
    // Wir nennen das eine Shadow Property und ist für uns meistens ein Fremdschlüssel, welcher
    // hier auf das Gericht verweist, zu dem dieser Schritt gehört.

    //public int MoreDishId { get; set; }
    // Wenn wir die obere Zeile schreiben ist es keine Shadow Property mehr, und durch "NamensKonventionen" wird erkannt dass es sich hier um den Foreign key handelt.
    // Es muss also nicht [ForeignKey("MoreDish")] stehen.
    // Falls wir aber einen anderen Name außer MoreDishId verwenden, brauchen wir das Attribut [ForeignKey("MoreDish")]

    //[ForeignKey("MoreDish")]
    //public int EinSehrKomischerNameFuerDenFremdschluessel { get; set; }

    // Navigationseigenschaft zurück zum Gericht.
    public Dish MoreDish { get; set; }
}