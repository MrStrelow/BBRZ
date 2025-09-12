using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauraunt.Entities;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public List<string> Ingredients { get; set; } = new();
    public List<string> Steps { get; set; } = new();

}
