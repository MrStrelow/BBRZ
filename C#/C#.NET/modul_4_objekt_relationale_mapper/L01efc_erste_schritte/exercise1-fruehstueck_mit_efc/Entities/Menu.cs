using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MorgenstundRestaurant.Entities;

public class Menu
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();

    public decimal Price => Dishes.Sum(d => d.Price);
}
