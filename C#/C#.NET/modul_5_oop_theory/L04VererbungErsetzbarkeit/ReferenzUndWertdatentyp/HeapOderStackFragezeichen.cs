namespace stackorheap;

class RefRechteck
{
    public double Länge { get; set; }
    public double Breite { get; set; }
    public Object o { get; set; }
}

struct Rechteck
{
    public double Länge { get; set; }
    public double Breite { get; set; }
    public Object o { get; set; }
}

public class Program
{
    public static void Main()
    {
        Rechteck r1 = new Rechteck { Länge = 5, Breite = 10, o = new Object() };
        Rechteck r2 = r1;
        Console.WriteLine("wert: r2 = r1");
        Console.WriteLine(r1.o.GetHashCode());
        Console.WriteLine(r2.o.GetHashCode());
        r2.o = new Object(); 

        Console.WriteLine(r1.o.GetHashCode());
        Console.WriteLine(r2.o.GetHashCode());


        RefRechteck rr1 = new RefRechteck { Länge = 5, Breite = 10, o = new Object() };
        RefRechteck rr2 = rr1;
        Console.WriteLine("ref: rr2 = rr1");
        Console.WriteLine(rr1.o.GetHashCode());
        Console.WriteLine(rr2.o.GetHashCode());
        
        Console.WriteLine("ref: rr2.o = new");
        rr2.o = new Object();

        Console.WriteLine(rr1.o.GetHashCode());
        Console.WriteLine(rr2.o.GetHashCode());

    }
}