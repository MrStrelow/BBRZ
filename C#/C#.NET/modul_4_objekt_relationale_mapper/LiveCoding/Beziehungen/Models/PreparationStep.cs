using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beziehungen.Models;

public class PreparationStep
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instruction { get; set; }

    // -> n:m Beziehung einem Dish, denn ein Dish hat mehrere PreperationSteps, ein PreperationStep kann in mehreren Dishes sein.
    public List<Dish> Dishes { get; set; } 
}
