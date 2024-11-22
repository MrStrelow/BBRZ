using System;

public abstract class GeometrischeForm
{
    public abstract void Anzeigen();
}


public class Rechteck : GeometrischeForm
{
    protected float LaengeX { get; set; }
    protected float LaengeY { get; set; }

    // Invariante: LaengeX >= 0 && LaengeY >= 0
    public Rechteck(float laengeX, float laengeY)
    {
        if (laengeX <= 0 || laengeY <= 0)
            throw new ArgumentException("Länge muss größer als 0 sein.");
        LaengeX = laengeX;
        LaengeY = laengeY;
    }

    public override void Anzeigen()
    {
        Console.WriteLine($"Rechteck: LaengeX = {LaengeX}, LaengeY = {LaengeY}");
    }

    // Pre-Condition: faktor > 0
    public virtual void SkalierenX(float faktor)
    {
        if (faktor <= 0)
            throw new ArgumentException("Faktor muss größer als 0 sein.");
        LaengeX *= faktor;
        // Post-Condition: LaengeX = LaengeX * faktor && LaengeY = LaengeY
    }

    public void Skalieren(float faktor)
    {
        if (faktor <= 0)
            throw new ArgumentException("Faktor muss größer als 0 sein.");

        LaengeX *= faktor;
        LaengeY *= faktor;
        // Post-Condition: RadiusX = radiusX * faktor && radiusY = radiusY * faktor
    }
}


public class Quadrat : Rechteck
{
    // Invariante: LaengeX >= 0 && LaengeY >= 0
    // Invariante: LaengeX == LaengeY, Quadrat stellt sicher, dass Länge X und Y immer gleich sind
    public Quadrat(float seitenLaenge) : base(seitenLaenge, seitenLaenge)
    {
    }

    // Pre-Condition: faktor > 0
    public override void SkalierenX(float faktor)
    {
        //?
        // Post-Condition: LaengeX = LaengeX * faktor && LaengeY = LaengeY
    }

    public override void Anzeigen()
    {
        Console.WriteLine($"Quadrat: Seitenlänge = {LaengeX}");
    }
}

public class Ellipse : GeometrischeForm
{
    protected float RadiusX { get; set; }
    protected float RadiusY { get; set; }

    // Invariante: RadiusX >= 0 && RadiusY >= 0
    public Ellipse(float radiusX, float radiusY)
    {
        if (radiusX <= 0 || radiusY <= 0)
            throw new ArgumentException("Radius muss größer als 0 sein.");

        RadiusX = radiusX;
        RadiusY = radiusY;
    }

    public override void Anzeigen()
    {
        Console.WriteLine($"Ellipse: RadiusX = {RadiusX}, RadiusY = {RadiusY}");
    }

    // Pre-Condition: faktor > 0
    public virtual void SkalierenX(float faktor)
    {
        if (faktor <= 0)
            throw new ArgumentException("Faktor muss größer als 0 sein.");

        RadiusX *= faktor;
        // Post-Condition: RadiusX = radiusX * faktor && radiusY = radiusY
    }

    // Pre-Condition: faktor > 0
    public void Skalieren(float faktor)
    {
        if (faktor <= 0)
            throw new ArgumentException("Faktor muss größer als 0 sein.");

        RadiusX *= faktor;
        RadiusY *= faktor;
        // Post-Condition: RadiusX = radiusX * faktor && radiusY = radiusY * faktor
    }
}

// Kreis (erbt von Ellipse)
public class Kreis : Ellipse
{
    // Invariante: RadiusX >= 0 && RadiusY >= 0
    // Invariante: RadiusX == RadiusY, Quadrat stellt sicher, dass Länge X und Y immer gleich sind
    public Kreis(float radius) : base(radius, radius)
    {
    }

    // Pre-Condition: faktor > 0
    public override void SkalierenX(float faktor)
    {
        // ?
        // Post-Condition: RadiusX = radiusX * faktor && radiusY = radiusY
    }

    public override void Anzeigen()
    {
        Console.WriteLine($"Kreis: Radius = {RadiusX}");
    }
}

// Testprogramm
public class Program
{
    public static void Main()
    {
        Rechteck rechteck = new Rechteck(5, 10);
        rechteck.Anzeigen();
        rechteck.SkalierenX(2);
        rechteck.Anzeigen();

        Quadrat quadrat = new Quadrat(4);
        quadrat.Anzeigen();
        quadrat.SkalierenX(2);
        quadrat.Anzeigen();

        Ellipse ellipse = new Ellipse(6, 8);
        ellipse.Anzeigen();
        ellipse.SkalierenX(0.5f);
        ellipse.Anzeigen();

        Kreis kreis = new Kreis(7);
        kreis.Anzeigen();
        kreis.SkalierenX(3);
        kreis.Anzeigen();
    }
}
