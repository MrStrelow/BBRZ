using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beziehungen.Models;

public class Visit
{
    public int Id { get; set; }
    public DateTime TimeOfVisit { get; set; }
    public List<Dish> Dishes { get; set; }
    public Table TableUsedDuringVisit { get; set; }
    public Customer Customer { get; set; }
}
