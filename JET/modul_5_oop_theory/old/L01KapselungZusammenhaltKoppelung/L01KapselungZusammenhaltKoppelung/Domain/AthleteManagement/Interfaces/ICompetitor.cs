using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L01KapselungZusammenhaltKoppelung;

interface ICompetitor<T> where T : ICompetitor<T>
{
    T Compete(T opponent);
}
