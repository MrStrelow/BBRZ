using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte
{
    internal interface IZahl
    {
        Zahl sumDezimal(DezimaleZahl zahl);
        Zahl sumBinaer(BinaereZahl zahl);

    }
}
