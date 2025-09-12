using System;

namespace polymorphism;

public abstract class GeometrischeForm
{
    public abstract double BerechneFläche();
}

public class Rechteck : GeometrischeForm
{
    public double Länge { get; set; }
    public double Breite { get; set; }

    public Rechteck(double länge, double breite)
    {
        Länge = länge;
        Breite = breite;
    }

    public override double BerechneFläche()
    {
        return Länge * Breite;
    }
}

public class Kreis : GeometrischeForm
{
    public double Radius { get; set; }

    public Kreis(double radius)
    {
        Radius = radius;
    }

    public override double BerechneFläche()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Program
{
    public static void Main()
    {
        GeometrischeForm[] formen =
        {
            new Rechteck(5, 10),
            new Kreis(7)
        };

        foreach (var form in formen)
        {
            Console.WriteLine($"Fläche: {form.BerechneFläche():F2}");
        }
    }
}
