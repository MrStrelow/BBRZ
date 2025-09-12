public interface GeometrischeForm
{

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

    public void SkalierenX(float faktor)
    {
        Länge *= faktor;
    }

    public void SkalierenY(float faktor)
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

    public void Skalieren(float faktor)
    {
        _rechteck.SkalierenX(faktor);
        _rechteck.SkalierenY(faktor); // Sicherstellen, dass beide Achsen gleich skaliert werden.
    }
}