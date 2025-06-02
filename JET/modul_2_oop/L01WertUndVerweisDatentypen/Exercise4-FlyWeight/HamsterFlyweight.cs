using System.Text;
using System.Linq;

namespace ReferenzUndWertDaten;

public class HamsterFlyweight
{
    static void Main(string[] args)
    {
        string darstellungFuerAlleImmutable = "🐹";
        var darstellungFuerAlleMutable = new MutableString { Symbol = darstellungFuerAlleImmutable };
        Console.OutputEncoding = Encoding.UTF8;

        HamsterMitImmutableDarstellung hempterImmOne = new() { Darstellung = darstellungFuerAlleImmutable };
        HamsterMitImmutableDarstellung hempterImmTwo = new() { Darstellung = darstellungFuerAlleImmutable };
        HamsterMitImmutableDarstellung hempterImmThree = new() { Darstellung = darstellungFuerAlleImmutable };

        HamsterMitMutableDarstellung hempterMuteOne = new() { Darstellung = darstellungFuerAlleMutable };
        HamsterMitMutableDarstellung hempterMuteTwo = new() { Darstellung = darstellungFuerAlleMutable };
        HamsterMitMutableDarstellung hempterMuteThree = new() { Darstellung = darstellungFuerAlleMutable };

        // Ausgabe all dieser Hamster
        var hamstersImm = new List<HamsterMitImmutableDarstellung> { hempterImmOne, hempterImmTwo, hempterImmThree };
        var hamstersMute = new List<HamsterMitMutableDarstellung> { hempterMuteOne, hempterMuteTwo, hempterMuteThree };

        foreach (var (mute, imm) in hamstersImm.Zip(hamstersMute))
        {
            Console.WriteLine(mute.Darstellung);
            Console.WriteLine(imm.Darstellung.Symbol);
        }

        // Ändere die Darstellung für alle Hamster
        darstellungFuerAlleImmutable = "🧱";
        darstellungFuerAlleMutable.Symbol = "🧱"; // strigs sind immuatable...
                                                  // also auch wenn wir explizit new string() sagen, gibt es noch immer
                                                  // einen string welcher "🐹" ist. "🧱" wird im speicher nun zusätzlich angelegt.
                                                  // Wir dürfen also nicht string verwenden, denn dieser ist ein spezieller
                                                  // referenztyp, eben eine immutable reference. 

        // Wenn wir wiklich sehen wollen, dass alle Hamster eine Referenz auf darstellungFürAlle haben, dann brauchen wir mutable daten.
        // Wir simulieren das mit einer eigenen Klasse, diese ist mutable.
        // Wir nennen diese MutableString und geben dieser ein Feld mit typ string.
        Console.WriteLine();

        foreach (var (mute, imm) in hamstersImm.Zip(hamstersMute))
        {
            Console.WriteLine(mute.Darstellung);
            Console.WriteLine(imm.Darstellung.Symbol);
        }
    }
}

public class HamsterMitMutableDarstellung
{
    public MutableString Darstellung { get; set; }
}

public class HamsterMitImmutableDarstellung
{
    public string Darstellung { get; set; }
}

public class MutableString
{
    public string Symbol { get; set; }
}