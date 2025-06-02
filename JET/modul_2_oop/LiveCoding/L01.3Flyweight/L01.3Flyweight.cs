using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReferenzUndWertDaten;

public class HamsterFlyweight
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        Hamster hempterOne = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterTwo = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterThree = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterFour = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterFive = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterSix = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterSeven = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterEight = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterNine = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterTen = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterEleven = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterTwelve = new Hamster { Darstellung = darstellungFuerAlle };
        Hamster hempterThirteen = new Hamster { Darstellung = darstellungFuerAlle };

        // Ausgabe all dieser Hamster
        var hamsters = new List<Hamster> { hempterOne, hempterTwo, hempterThree };

        foreach (var hamster in hamsters)
        {
            Console.WriteLine(hamster.Darstellung.Symbol);
        }

        // Ändere die Darstellung für alle Hamster
        darstellungFuerAlle.Symbol = "🧱"; // strigs sind immuatable...
                                                // also auch wenn wir explizit new string() sagen, gibt es noch immer
                                                // einen string welcher "🐹" ist. "🧱" wird im speicher nun zusätzlich angelegt.
                                                // Wir dürfen also nicht string verwenden, denn dieser ist ein spezieller
                                                // referenztyp, eben eine immutable reference. 

        // Wenn wir wiklich sehen wollen, dass alle Hamster eine Referenz auf darstellungFürAlle haben, dann brauchen wir mutable daten.
        // Wir simulieren das mit einer eigenen Klasse, diese ist mutable.
        // Wir nennen diese MutableString und geben dieser ein Feld mit typ string.
        Console.WriteLine();

        foreach (var hamster in hamsters)
        {
            Console.WriteLine(hamster.Darstellung.Symbol);
        }
    }
}

public class Hamster
{
    public MutableString Darstellung { get; set; }
}

public class MutableString
{
    public string Symbol { get; set; }
}