using System;

public struct Rechteck
{
    public double Länge { get; set; }
    public double Breite { get; set; }

    public Rechteck(double länge, double breite)
    {
        Länge = länge;
        Breite = breite;
    }

    public double BerechneFläche()
    {
        return Länge * Breite;
    }
}

public struct Kreis
{
    public double Radius { get; set; }

    public Kreis(double radius)
    {
        Radius = radius;
    }

    public double BerechneFläche()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Program
{
    public static void Main()
    {
        // Verwenden von Tupeln, um unterschiedliche Typen zu speichern
        var formen = new object[]
        {
            new Rechteck(5, 10),
            new Kreis(7)
        };

        foreach (var form in formen)
        {
            if (form is Rechteck rechteck)
            {
                Console.WriteLine($"Rechteck Fläche: {rechteck.BerechneFläche():F2}");
            }
            else if (form is Kreis kreis)
            {
                Console.WriteLine($"Kreis Fläche: {kreis.BerechneFläche():F2}");
            }
        }
    }
}
