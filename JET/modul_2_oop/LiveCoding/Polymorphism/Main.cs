using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism;

internal class MainProg
{
    static void Main(string[] args)
    {
        Hund hund = new Hund();
        SchaeferHund schaefer = new SchaeferHund();

        var hunde = new List<Hund> { schaefer, hund };

        foreach (var elems in hunde)
        {
            elems.bellen();

            // "pattern matching style" - verwende das.
            if (elems is SchaeferHund schaeferHund)
            {
                schaeferHund.heuten();
            }

            // "saver older c# style" - as versucht es und liefert null wenns fehlschlägt.
            //if (elems is SchaeferHund)
            //{
            //    var elemsPossibleNull = elems as SchaeferHund;
                
            //    if (elemsPossibleNull is not null)
            //    {
            //        elemsPossibleNull.heuten();
            //    }
            //}

            // "risky older c# style" - as versucht es und liefert null wenns fehlschlägt.
            //if (elems is SchaeferHund)
            //{
            //    (elems as SchaeferHund).heuten();
            //}

            // "JAVA style" typecast - wandle um, falls es fehlschlägt wirf eine es exception. 
            // kann nicht fehlschlagen, da wir es vorher mit dem if abfragen.
            //if (elems is SchaeferHund)
            //{
            //    ((SchaeferHund)elems).heuten();
            //}
        }
    }
}
