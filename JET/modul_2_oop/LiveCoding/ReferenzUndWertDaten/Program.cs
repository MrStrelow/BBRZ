public class WertUndReferenzen
{
    static void Main(string[] args)
    {
        Hund hund = new() { Name = "hundos", Alter = 5 };
        Hund frido = new Hund { Name = "fridoro", Alter = 10 }; // beim Aufruf des Default-Konstruktors können die runden Klammern weggelassen werden.

        Console.WriteLine(hund.Alter);
        Console.WriteLine("asdf");

        Console.WriteLine(Equals(frido, hund));
        Console.WriteLine(ReferenceEquals(frido, hund));

        hund = frido;

        Console.WriteLine(hund.Alter);
        Console.WriteLine(frido.Alter);

        //Console.WriteLine(hund.Equals(frido));

        Console.WriteLine(Equals(frido, hund));
        Console.WriteLine(ReferenceEquals(frido, hund));

        hund.Alter = 5;

        Console.WriteLine(hund.Alter);
        Console.WriteLine(frido.Alter);
        
        frido.Alter = 100;
        
        Console.WriteLine(hund.Alter);
        Console.WriteLine(frido.Alter);

        // Wie erzeuge ich eine Kopie eines Referenzdatentyps, welche nicht die gleiche Referenz hat?
        
        
        // Was ist null bei Referenzdatentypen?
        hund.Besitzer = null;
        Console.WriteLine(hund.Besitzer);

        // (gibt es nicht bei Wertdatentypen... außer wir machen folgendes...)
    }
}

public class Hund
{
    public string? Name { get; set; }
    public int Alter
    {
        get; set
        {
            if (value > 20)
            {
                Alter = value;
            }
        }
    }

    public Besitzer Besitzer;
    
}

public class Besitzer
{
    public string? Name { get; set; }
    public int? Alter { get; set; }

    public Besitzer(int alter)
    {
        string bezeichnung = Name ?? "Unbekannt";

    }

    public void Test()
    {
        Alter = 0;
    }
}