using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restauraunt.Entities;

public class Bill
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int TableNumber { get; set; }
    public List<string> CustomerNames { get; set; } = new();
    public List<string> OrderedMenus { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
}
