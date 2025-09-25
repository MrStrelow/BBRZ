using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruehstuecksrestaurantMore.Models;

public class Visit
{
    public int Id { get; set; }
    public Table table { get; set; }
    public DateTime TimeOfVisit { get; set; } = DateTime.Now;
    public List<Dish> dishes { get; set; } = new List<Dish>();
    public Customer Customer { get; set; }
}
