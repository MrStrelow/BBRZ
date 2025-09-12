using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism;

public interface IHund
{
    public int Groesse { get; set; }
    void bellen();

    //Das geht nicht, keine Implementierung in einem Interface möglich
    //public override string ToString()
    //{
    //    return $"🐕{Groesse}🐶";
    //}
}
