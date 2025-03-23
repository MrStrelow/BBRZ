namespace Hunde;

public class Hund
{
    // Private Felder
    private string name;
    private int alter;
    private string geschlecht;
    private bool chipped;
    private double health;

    // Hat - Beziehungen
    private HundeBesitzer besitzer;
    private Hund spielFreund;

    // Konstruktoren
    public Hund(string name, int alter, string geschlecht, double health, bool chipped)
    {
        this.name = name;
        this.alter = alter;
        this.geschlecht = geschlecht;
        this.health = health;
        this.chipped = chipped;
        // Spielpartner und Besitzer sind null (0..1 Kardinalität)
    }

    public Hund(
        string name, int alter, string geschlecht, double health, 
        bool chipped, HundeBesitzer besitzer
    )
        : this(name, alter, geschlecht, health, chipped)
    {
        this.besitzer = besitzer;
        this.besitzer.AddHund(this);
    }

    public Hund(Hund toCopy)
    {
        this.name = toCopy.name;
        this.alter = toCopy.alter;
        this.geschlecht = toCopy.geschlecht;
        this.chipped = toCopy.chipped;
        this.health = toCopy.health;
    }


    public Hund(
        string name, int alter, string geschlecht, double health, 
        bool chipped, Hund spielFreund
    )
        : this(name, alter, geschlecht, health, chipped)
    {
        this.spielFreund = spielFreund;
        this.spielFreund.SetSpielFreund(this);
    }

    public Hund(
        string name, int alter, string geschlecht, double health, 
        bool chipped, HundeBesitzer besitzer, Hund spielFreund
    )
        : this(name, alter, geschlecht, health, chipped)
    {
        this.besitzer = besitzer;
        this.spielFreund = spielFreund;

        this.besitzer.AddHund(this);
        this.spielFreund.SetSpielFreund(this);
    }

    // Methoden
    public void Fressen(Essen essen)
    {
        Console.WriteLine($"{name} frisst {essen}");
    }

    public void Spielen()
    {
        Console.WriteLine(
            $"Mein Spielfreund: {spielFreund.name} spielt mit mir!: {this.name} unter " +
            $"der strengen aufsicht von: {besitzer.GetName()}");
    }

    public String Bellen()
    {
        Console.WriteLine($"{ this.name} bellt!");
        return "Geräusch eines Hundes.";
    }

    public void Weglaufen()
    {
        Console.WriteLine($"{this.name} ist von {this.besitzer} weggelaufen...");
        besitzer.Aussetzen(this);
        besitzer = null;
    }

    // überschriebene Methoden
    public override string ToString()
    {
        return $"{name}:{alter}";
    }

    // Get-und-Set-Methoden
    public void SetSpielFreund(Hund spielFreund)
    {
        this.spielFreund = spielFreund;

        if (spielFreund.spielFreund != this)
        {
            spielFreund.SetSpielFreund(this);
        }
    }

    public Hund GetSpielFreund()
    {
        return spielFreund;
    }

    public HundeBesitzer GetBesitzer()
    {
        return besitzer;
    }

    public void SetBesitzer(HundeBesitzer besitzer)
    {
        if (this.besitzer is null && !besitzer.BesitztHund(this))
        {
            this.besitzer = besitzer;
            besitzer.AddHund(this);

        }
        else
        {
            Console.WriteLine($"Zuweisung verboten! {this.GetName()} ist bereits besessen.");
        }
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public int GetAlter()
    {
        return alter;
    }

    public void SetAlter(int alter)
    {
        this.alter = alter;
    }

    public String GetGeschlecht()
    {
        return geschlecht;
    }

    public void SetGeschlecht(String geschlecht)
    {
        this.geschlecht = geschlecht;
    }

    public bool IsChipped()
    {
        return chipped;
    }

    public void SetChipped(bool chipped)
    {
        this.chipped = chipped;
    }

    public double GetHealth()
    {
        return health;
    }

    public void SetHealth(double health)
    {
        this.health = health;
    }
}
