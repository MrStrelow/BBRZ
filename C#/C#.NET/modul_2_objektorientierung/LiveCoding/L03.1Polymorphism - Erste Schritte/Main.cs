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
        Console.OutputEncoding = Encoding.UTF8;
        // Wenn wir vom Interface IHund in Pudel und SchaeferHund ableiten.
        IHund pudel = new Pudel() { Groesse = 20 };
        IHund schaefer = new SchaeferHund() { Groesse = 100 };
        var hunde = new List<IHund> { schaefer, pudel };

        // Wenn wir von der abstrakten Klasse Hund in Pudel und SchaeferHund ableiten.
        //Hund pudel = new Pudel() { Groesse = 20 };
        //Hund schaefer = new SchaeferHund() { Groesse = 100 };
        //var hunde = new List<IHund> { schaefer, pudel };

        foreach (var elems in hunde)
        {
            Console.WriteLine($"Hund: {elems} vom Typ: {elems.GetType()} hat groesse {elems.Groesse}");
            elems.bellen();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            // "pattern matching style" - verwende das.
            if (elems is SchaeferHund schaeferHund)
            {
                schaeferHund.hueten();
            }

            // "older c# style" - as versucht es und liefert null wenns fehlschlägt.
            
            //var elemsPossibleNull = elems as SchaeferHund;

            //if (elemsPossibleNull is not null)
            //{
            //    elemsPossibleNull.heuten();
            //}

            // "older c# style" - as versucht es und liefert null wenns fehlschlägt.
            // schlägt nicht fehl, da wir if haben
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
