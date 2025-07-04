using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal class JoinedData
{
    public int CustomerID { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    double Amount { get; set; }
    public string Product { get; set; }
    public DateTime Date { get; set; }
    public int? Quantity { get; set; }
}