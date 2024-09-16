using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

internal interface InterneZahlMult
{
    Zahl multDezimal(DezimaleZahl zahl);
    Zahl multBinaer(BinaereZahl zahl);
}
