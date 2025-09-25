namespace FruehstuecksrestaurantMore.Models;

// Diese Klasse repräsentiert ein komplexeres Gericht.
public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // Navigationseigenschaft für die 1:n-Beziehung zu den Zubereitungsschritten.
    public ICollection<PreparationStep> PreparationSteps { get; set; } = new List<PreparationStep>();

    // Navigationseigenschaft für die n:m-Beziehung zu den Zutaten.
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}