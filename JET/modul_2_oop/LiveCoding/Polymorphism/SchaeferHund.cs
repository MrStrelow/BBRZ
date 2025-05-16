using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism;

public class SchaeferHund : IHund, IFreund
{
    public int Groesse { get; set; }
    public void bellen()
    {
        Console.WriteLine("ich belle wie ein Schaefer.");
    }

    public void freundSein()
    {
        Console.WriteLine("Freund.");
    }

    public void hueten()
    {
        Console.WriteLine("ich huete.");
    }
}
