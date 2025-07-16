    using System.Collections.Generic;

namespace MorgenstundRestaurant.Entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> Ingredients { get; set; } = new();
    public List<string> PreparationSteps { get; set; } = new();
    public decimal Price { get; set; }
}
