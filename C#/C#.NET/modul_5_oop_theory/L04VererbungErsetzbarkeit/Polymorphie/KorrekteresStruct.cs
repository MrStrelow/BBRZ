namespace interfaceundstruct;
interface IForm
{
    double BerechneFläche();
}

public struct Rechteck : IForm
{
    public double Länge { get; set; }
    public double Breite { get; set; }

    public Rechteck(double länge, double breite)
    {
        Länge = länge;
        Breite = breite;
    }

    public double BerechneFläche() => Länge * Breite;
}

public struct Kreis : IForm
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

        // Boxing: Das Struct wird auf den Heap kopiert!
        IForm[] formen =
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
