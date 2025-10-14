namespace Hunde;

public class Hund
{
    // Private Felder
    private string _name;
    private int _alter;
    private string _geschlecht;
    private bool _chipped;
    private double _health;
    private string _darstellung = "🐶";
    private string _lautBeimBellen = "➡️wuff⬅️";

    // Hat - Beziehungen
    private HundeBesitzer _besitzer;
    private Hund _spielFreund;

    // Konstruktoren
    public Hund(string name, int alter, string geschlecht, double health, bool chipped)
    {
        _name = name;
        _alter = alter;
        _geschlecht = geschlecht;
        _health = health;
        _chipped = chipped;
        // Spielpartner und Besitzer sind null (0..1 Kardinalität)
    }

    public Hund(
        string name, int alter, string geschlecht, double health, 
        bool chipped, HundeBesitzer besitzer
    ) : this(
            name, alter, geschlecht, health, chipped
        )
    {
        _besitzer = besitzer;
        _besitzer.AddHund(this);
    }

    public Hund(Hund toCopy)
    {
        _name = toCopy._name;
        _alter = toCopy._alter;
        _geschlecht = toCopy._geschlecht;
        _chipped = toCopy._chipped;
        _health = toCopy._health;
    }

    public Hund(
        string name, int alter, string geschlecht, double health, 
        bool chipped, Hund spielFreund
    ) : this(
            name, alter, geschlecht, health, chipped
        )
    {
        _spielFreund = spielFreund;
        _spielFreund.SetSpielFreund(this);
    }

    public Hund(
        string name, int alter, string geschlecht, double health, 
        bool chipped, HundeBesitzer besitzer, Hund spielFreund
    ) : this(
            name, alter, geschlecht, health, chipped
        )
    {
        _besitzer = besitzer;
        _spielFreund = spielFreund;

        _besitzer.AddHund(this);
        _spielFreund.SetSpielFreund(this);
    }

    // Methoden
    public void Fressen(Essen essen)
    {
        Console.WriteLine($"{this} frisst {essen}");
    }

    public void Spielen()
    {
        Console.WriteLine(
            $"Mein Spielfreund: {_spielFreund} spielt mit mir!: {this} unter " +
            $"der strengen aufsicht von: {_besitzer}");
    }

    public string Bellen()
    {
        Console.WriteLine($"{this} bellt!");
        return "Geräusch eines Hundes.";
    }

    public void Weglaufen()
    {
        Console.WriteLine($"{_name} ist von {_besitzer} weggelaufen...");
        _besitzer.Aussetzen(this);
        _besitzer = null;
    }

    // überschriebene Methoden
    public override string ToString()
    {
        return $"{_name}:{_alter}:{_darstellung}";
    }

    // Get-und-Set-Methoden
    public void SetSpielFreund(Hund spielFreund)
    {
        _spielFreund = spielFreund;

        if (spielFreund._spielFreund != this)
        {
            spielFreund.SetSpielFreund(this);
        }
    }

    public Hund GetSpielFreund()
    {
        return _spielFreund;
    }

    public HundeBesitzer GetBesitzer()
    {
        return _besitzer;
    }

    public void SetBesitzer(HundeBesitzer besitzer)
    {
        if (besitzer is null)
        {
            Console.WriteLine($"Parameter besitzer von SetBesitzer in Hund ist null.");
            return;
        }

        if (besitzer.BesitztHund(this))
        {
            Console.WriteLine($"Zuweisung verboten! {this} ist bereits besessen 👻.");
            return;
        }

        _besitzer = besitzer;
        besitzer.AddHund(this);
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public int GetAlter()
    {
        return _alter;
    }

    public void SetAlter(int alter)
    {
        _alter = alter;
    }

    public string GetGeschlecht()
    {
        return _geschlecht;
    }

    public void SetGeschlecht(string geschlecht)
    {
        _geschlecht = geschlecht;
    }

    public bool IsChipped()
    {
        return _chipped;
    }

    public void SetChipped(bool chipped)
    {
        _chipped = chipped;
    }

    public double GetHealth()
    {
        return _health;
    }

    public void SetHealth(double health)
    {
        _health = health;
    }

    public string GetDarstellung()
    {
        return _darstellung;
    }

    public void SetDarstellung(string darstellung)
    {
        _darstellung = darstellung;
    }

    public string GetLautBeimBellen()
    {
        return _lautBeimBellen;
    }

    public void SetLautBeimBellen(string lautBeimBellen)
    {
        _lautBeimBellen = lautBeimBellen;
    }

}
