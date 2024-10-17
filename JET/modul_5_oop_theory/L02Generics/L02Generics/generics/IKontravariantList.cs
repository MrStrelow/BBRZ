using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solution;

internal interface IKontravariantList<in T>
{
    //T Get(int index);
    void Add(T element);
}
