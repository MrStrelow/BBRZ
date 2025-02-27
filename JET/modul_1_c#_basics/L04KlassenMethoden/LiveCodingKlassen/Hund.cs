namespace LiveCodingKlassen;

public class Hund
{
    // Felder
    private string name;
    private int alter;
    private string geschlecht;
    private bool chipped;
    private double health;

    // Hat - Beziehungen
    private HundeBesitzer besitzer;
    private Hund spielFreund;

    // Methoden:
    // - Konstruktor
    public Hund(string name, bool chipped)
    {
        this.name = name;
        this.alter = 1;

        Random random = new Random();
        int draw = random.Next(minValue: 0, maxValue: 2);
        string[] geschlecht = { "maennlich", "weiblich" };
        this.geschlecht = geschlecht[draw];

        //this.geschlecht = random.Next() == 0 ? "maennlich" : "weiblich";

        this.chipped = chipped;
        this.health = 15;
    }

    public Hund(Hund toCopy)
    {
        this.name = toCopy.name;
        this.alter = toCopy.alter;
        this.geschlecht = toCopy.geschlecht;
        this.chipped = toCopy.chipped;
        this.health = toCopy.health;
    }

    // - Verhaltensmethoden
    public void Fressen(Essen essen)
    {
        throw new NotImplementedException();
    }

    public void Spielen()
    {
        health += 10;
        spielFreund.health += 10;
        throw new NotImplementedException();
    }

    public string Bellen()
    {
        throw new NotImplementedException();
    }

    public void weglaufen()
    {
        throw new NotImplementedException();
    }

    // - Get-Set Methoden
}
