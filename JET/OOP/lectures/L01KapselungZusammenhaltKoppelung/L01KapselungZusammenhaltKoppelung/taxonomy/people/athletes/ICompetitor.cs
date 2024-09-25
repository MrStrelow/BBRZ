using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L01KapselungZusammenhaltKoppelung;

internal interface ICompetitor<T> where T : ICompetitor<T>
{
    public T Compete(T opponent);
}
