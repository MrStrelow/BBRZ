using System.Collections.Generic;

namespace FruehstuecksrestaurantMore.Models;

// Repräsentiert eine Zutat, die in mehreren Gerichten vorkommen kann.
public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; } // z.B. "g", "ml", "Stück"

    // Navigationseigenschaft, damit wir sehen können, in welchen Gerichten diese Zutat verwendet wird.
    public ICollection<MoreDish> MoreDishes { get; set; } = new List<MoreDish>();
}