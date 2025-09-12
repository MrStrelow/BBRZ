using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Restauraunt.Entities;

public class Menu
{    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<int> DishIds { get; set; } = new();

    [JsonIgnore]
    public List<Dish> Dishes { get; set; } = new();

    [JsonIgnore]
    public decimal Price => Dishes.Sum( d => d.Price);
}
