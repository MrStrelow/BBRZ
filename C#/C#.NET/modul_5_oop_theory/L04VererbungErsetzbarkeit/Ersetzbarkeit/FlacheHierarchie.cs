namespace flach;

public abstract class GeometrischeForm
{
    public abstract void SkalierenX(float faktor);
    public abstract void SkalierenY(float faktor);
}

public class Rechteck : GeometrischeForm
{
    public float Länge { get; private set; }
    public float Breite { get; private set; }

    public Rechteck(float länge, float breite)
    {
        Länge = länge;
        Breite = breite;
    }

    public override void SkalierenX(float faktor)
    {
        Länge *= faktor;
    }

    public override void SkalierenY(float faktor)
    {
        Breite *= faktor;
    }
}

public class Quadrat : GeometrischeForm
{
    public float Seitenlänge { get; private set; }

    public Quadrat(float seitenlänge)
    {
        Seitenlänge = seitenlänge;
    }

    public override void SkalierenX(float faktor)
    {
        Seitenlänge *= faktor;
    }

    public override void SkalierenY(float faktor)
    {
        Seitenlänge *= faktor; // Beide Achsen müssen gleich skaliert werden.
    }
}
