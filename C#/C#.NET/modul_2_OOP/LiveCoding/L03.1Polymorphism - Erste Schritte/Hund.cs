using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism;

public abstract class Hund
{
    public int Groesse { get; set; }
    public abstract void bellen();

    public override string ToString()
    {
        return $"🐕{Groesse}🐶";
    }
}
