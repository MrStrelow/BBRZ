using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beziehungen.Model;

internal class PreparationStep
{
    public int Id { get; set; }
    public int StepNumber { get; set; }
    public string Instruction { get; set; }
    public Dish MyDish { get; set; } // -> bidirektionale Beziehung zu einem Dish, denn ein Dish hat mehrere PreperationSteps
}
