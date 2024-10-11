using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution;

internal interface ICovariantList<out T>
{
    T Get(int index);
    // void T Add(T element); // Fehler, da nicht Contravariant
}
