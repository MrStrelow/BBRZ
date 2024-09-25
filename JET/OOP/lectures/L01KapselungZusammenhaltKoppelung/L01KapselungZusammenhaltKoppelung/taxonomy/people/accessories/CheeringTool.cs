using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal abstract class CheeringTool : Tool
{
    // use me ist abhängig davon welcher fan es verwendet (auch in welchem Spiel) ...
    // multi methods, double dispatch, visitor pattern, covariance?
    public abstract string UseMe();
}
