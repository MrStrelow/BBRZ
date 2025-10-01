using System.Collections.Generic;

namespace FruehstuecksBestellungMVC.Models;

public class Ingredient
{
    public int IngredientId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Dish? Dish { get; set; }
}