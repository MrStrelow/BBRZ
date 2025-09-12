using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution;

internal class KontravarianteList<T> : IKontravariantList<T>
{
    private T? _element;

    public KontravarianteList(T element)
    {
        _element = element;
    }

    public void Add(T element)
    {
        _element = element;
    }
}
