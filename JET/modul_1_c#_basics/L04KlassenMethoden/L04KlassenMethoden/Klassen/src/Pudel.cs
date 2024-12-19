namespace Hunde;

public class Pudel : Hund // Ist-Beziehungen
{
    // private Felder
    private double fluff;

    // Konstruktor
    public Pudel(string name, int alter, string geschlecht, Double health, bool chipped, double fluff) 
        : base(name, alter, geschlecht, health, chipped)
    {
        this.fluff = fluff;
    }

    public Pudel(
        string name, int alter, string geschlecht, Double health, bool chipped, 
        double fluff, HundeBesitzer besitzer, Hund spielFreund
    ) 
        : this(name, alter, geschlecht, health, chipped, fluff)
    {
        this.SetBesitzer(besitzer);
        this.SetSpielFreund(spielFreund);
    }

    public Pudel(
        string name, int alter, string geschlecht, Double health, 
        bool chipped, double fluff, HundeBesitzer besitzer
    ) 
        : this(name, alter, geschlecht, health, chipped, fluff)
    {
        
        this.SetBesitzer(besitzer);
    }

    public Pudel(
        string name, int alter, string geschlecht, Double health, bool chipped, double fluff, Hund spielFreund
    )
        : this(name, alter, geschlecht, health, chipped, fluff)
    {


        this.SetSpielFreund(spielFreund);
    }

    // Methoden
    public void Winseln()
    {
        Console.WriteLine(".... ewww");
        SetHealth(GetHealth() - 1);
    }

    // Get-und-Set-Methoden
    public double GetFluff()
    {
        return fluff;
    }

    public void SetFluff(double fluff)
    {
        this.fluff = fluff;
    }
}