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
        
        
       // Was ist null bei Referenzdatentypen?
       hund.Besitzer = null;
       Console.WriteLine(hund.Besitzer);

       // (gibt es nicht bei Wertdatentypen... außer wir machen folgendes... auch ein ? neben der variable int alter schreiben)
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

   //public int Alter // Warum geht das nicht? 
   //{
   //    get; set
   //    {
   //        if (value > 20)
   //        {
   //            Alter = value;
   //        }
   //    }
   //}

   private int _alter; // Wir brauchen!, was gibt nun get; zurück? Warum ist es immer noch 0, wenn wir es doch gesetzt haben?
   //public int Alter
   //{
   //    get; set
   //    {
   //        if (value > 20)
   //        {
   //            _alter = value;
   //        }
   //    }
   //}

   //public int Alter // wir müssen auch das get mit dem feld _alter verbinden. Wir haben also wieder die get und set methoden wie in JAVA.
   //{
   //    get {
   //        return _alter;
   //    }
   //    set
   //    {
   //        if (value > 20)
   //        {
   //            _alter = value;
   //        }
   //    }
   //}

   // die kürzeste version benötigt jedoch noch den "Lambda" Operator sowie "Expressions".
   //public int Alter
   //{
   //    get => _alter;
   //    set => _alter = value > 20 ? value : _alter;  
   //}

   // verwende die die klammern für komplizierteren Ausdrücke und für kurze die =>
   public int Alter
   {
       get => _alter;
       set
       {
           if (value <= 20)
           {
               throw new ArgumentException("Alter must be greater than 20");
           }

           _alter = value;
       }
   }

   public Besitzer Besitzer;
    
}