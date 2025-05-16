using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism;

public class Pudel : Hund
{
    public override void bellen()
    {
        Console.WriteLine("ich belle wie ein Pudel.");
    }
}
