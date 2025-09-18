using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beziehungen.Model;
public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }

    // -> hier ist die n zu m Beziehung zu Dishes.
    public List<Dish> Dishes { get; set; } = new List<Dish>();
}
