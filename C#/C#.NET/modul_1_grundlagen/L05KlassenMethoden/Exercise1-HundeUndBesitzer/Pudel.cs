namespace Hunde;

public class Pudel : Hund // Ist-Beziehungen
{
    // private Felder
    private double _fluff;

    // Konstruktor
    public Pudel(
        string name, int alter, string geschlecht, 
        double health, bool chipped, double fluff
    ) : base(
            name, alter, geschlecht, health, chipped
        )
    {
        _fluff = fluff;
        SetDarstellung("🐩");
        SetLautBeimBellen("⬆️Ieek⬆️");
    }

    public Pudel(
        string name, int alter, string geschlecht, 
        double health, bool chipped, double fluff, 
        HundeBesitzer besitzer, Hund spielFreund
    ) : this(
            name, alter, geschlecht, health, chipped, fluff
        )
    {
        SetBesitzer(besitzer);
        SetSpielFreund(spielFreund);
    }

    public Pudel(
        string name, int alter, string geschlecht, double health, 
        bool chipped, double fluff, HundeBesitzer besitzer
    ) : this(
            name, alter, geschlecht, health, chipped, fluff
        )
    {
        SetBesitzer(besitzer);
    }

    public Pudel(
        string name, int alter, string geschlecht, 
        double health, bool chipped, double fluff, 
        Hund spielFreund
    ) : this(
            name, alter, geschlecht, health, chipped, fluff
        )
    {
        SetSpielFreund(spielFreund);
    }

    // Methoden
    public void Winseln()
    {
        Console.WriteLine(".winsel.");
        SetHealth(GetHealth() - 1);
    }

    // Get-und-Set-Methoden
    public double GetFluff()
    {
        return _fluff;
    }

    public void SetFluff(double fluff)
    {
        _fluff = fluff;
    }
}