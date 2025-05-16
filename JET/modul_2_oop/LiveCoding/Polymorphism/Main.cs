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

            if (elems is SchaeferHund schaeferHund)
            {
                schaeferHund.heuten();
            }

            //if (elems is SchaeferHund)
            //{
            //    ((SchaeferHund)elems).heuten();
            //}
        }
    }
}
