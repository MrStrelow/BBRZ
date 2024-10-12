using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEfCore.Models;

internal class OrderDetail
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    // shadow propperty: ist ein foreign key in der datenbank, wird durch Order und Product  darunter erzeugt, aber kann auch direkt hier angegeben werden.
    //public int ProductId { get; set; }
    //public int OrderId { get; set; }

    public Order Order { get; set; } = null!;
    public Product Product { get; set; } = null!;
}
