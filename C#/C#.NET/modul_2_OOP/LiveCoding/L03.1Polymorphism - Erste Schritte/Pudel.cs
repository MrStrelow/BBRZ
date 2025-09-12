using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism;

public class Pudel : IHund
{
    public int Groesse { get; set; }
    
    public void bellen()
    {
        Console.WriteLine("ich belle wie ein Pudel.");
    }

    public override string ToString(){
        return $"🐶{Groesse}";
    }
}
