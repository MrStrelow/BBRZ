namespace delegation;

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
    private Rechteck _rechteck;

    public Quadrat(float seitenlänge)
    {
        _rechteck = new Rechteck(seitenlänge, seitenlänge);
    }

    public float Seitenlänge
    {
        get => _rechteck.Länge;
        private set
        {
            _rechteck = new Rechteck(value, value);
        }
    }

    public override void SkalierenX(float faktor)
    {
        _rechteck.SkalierenX(faktor);
        _rechteck.SkalierenY(faktor); // Sicherstellen, dass beide Achsen gleich skaliert werden.
    }

    public override void SkalierenY(float faktor)
    {
        _rechteck.SkalierenX(faktor); // Gleiche Logik wie SkalierenX.
        _rechteck.SkalierenY(faktor);
    }
}
