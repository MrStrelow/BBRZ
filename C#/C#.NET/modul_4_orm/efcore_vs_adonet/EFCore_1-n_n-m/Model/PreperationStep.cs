// Repräsentiert einen einzelnen Zubereitungsschritt.
namespace FruehstuecksrestaurantMore.Models;

public class PreparationStep
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instruction { get; set; }

    // Fremdschlüssel, der auf das Gericht verweist, zu dem dieser Schritt gehört.
    public int MoreDishId { get; set; }
    // Navigationseigenschaft zurück zum Gericht.
    public Dish MoreDish { get; set; }
}