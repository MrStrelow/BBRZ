using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution;

internal class KovarianteList<T> : ICovariantList<T>
{
    private T _element;

    public KovarianteList(T element)
    {
        _element = element;
    }

    public T Get(int index)
    {
        return _element;
    }
}
