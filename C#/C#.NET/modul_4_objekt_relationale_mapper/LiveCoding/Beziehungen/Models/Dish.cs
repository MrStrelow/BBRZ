using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beziehungen.Models;

public class Dish
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    // -> 1 zu n Beziehung: ein Dish hat mehrere PreperationSteps
    public List<PreparationStep> PreparationSteps { get; set; } = new List<PreparationStep>();

    // -> n zu m Beziehung: ein Dish hat mehrere Ingredients
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
 }
