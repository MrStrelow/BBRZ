public class WertUndReferenzen
{
   static void Main(string[] args)
   {
       Hund hund = new() { Name = "hundos", Alter = 25 };
       Console.WriteLine(hund.Alter);

       Hund frido = new Hund { Name = "fridoro", Alter = 10 }; // beim Aufruf des Default-Konstruktors können die runden Klammern weggelassen werden.

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
       // für uns bis jetzt: copy constructor erstellen.

       // Was ist null bei Referenzdatentypen?
       hund.Besitzer = null;
       Console.WriteLine(hund.Besitzer);

       // (gibt es nicht bei Wertdatentypen... außer wir machen folgendes... auch ein ? neben dem Feld int alter schreiben)
   }
}
public class Besitzer
{
   public string Name { get; set; }
   public int Alter { get; set; }

   public Besitzer(string name)
   {
        if (Name is null)
        {
            Name = "Unbekannt";
        }
        else
        {
            Name = name;
        }
   }
}

public class Hund
{
    public string Name { get; set; }
    public int Alter { get; set; }
    public Besitzer Besitzer { get; set; }
}