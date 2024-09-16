using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEfCore.Models;
class Order
{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime? OrderFulfilled { get; set; }

    // shadow propperty: ist ein foreign key in der datenbank, wird durch Customer darunter erzeugt, aber kann auch direkt hier angegeben werden.
    //public int CustomerId { get; set; } 

    public Customer Customer { get; set; } = null!;
    public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
}

