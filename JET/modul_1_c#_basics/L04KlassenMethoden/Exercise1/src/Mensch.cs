namespace Hunde;

public class Mensch
{
    // private Felder
    private string name;
    private int alter;
    private double happiness;

    // hat-Beziehungen:
    private Mensch loveInterest;

    // Konstruktor
    public Mensch(string name, double happiness, int alter)
    {
        this.name = name;
        this.happiness = happiness;
        this.alter = alter;
    }

    public Mensch(string name, double happiness, int alter, Mensch loveInterest) : this(name, happiness, alter)
    {
        this.loveInterest = loveInterest;
    }

    //Methoden
    public HundeBesitzer WirdEinHundeBesitzer(Hund hund, bool hatHundeFuehrerschein, int capacity)
    {
        HundeBesitzer einGanzNeuerMensch = new HundeBesitzer(this, hatHundeFuehrerschein, capacity);
        einGanzNeuerMensch.Kaufen(hund);
        return einGanzNeuerMensch;
    }

    public HundeBesitzer MehrereHundeKaufen(Hund[] hunde, bool hatHundeFuehrerschein, int capacity)
    {
        HundeBesitzer einGanzNeuerMensch = new HundeBesitzer(this, hatHundeFuehrerschein, capacity);

        if (capacity <= hunde.Length)
        {
            Console.WriteLine("Fehler! Wir haben zu viele Hunde als wir betreuen können.");
            return null;
        }

        foreach (Hund hund in hunde)
        {
            einGanzNeuerMensch.Kaufen(hund);
        }

        return einGanzNeuerMensch;
    }

    // Get-und-Set-Methoden
    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public double GetHappiness()
    {
        return happiness;
    }

    public void SetHappiness(double happiness)
    {
        this.happiness = happiness;
    }

    public int GetAlter()
    {
        return alter;
    }

    public void SetAlter(int alter)
    {
        this.alter = alter;
    }

    public Mensch GetLoveInterest()
    {
        return loveInterest;
    }

    public void SetLoveInterest(Mensch loveInterest)
    {
        this.loveInterest = loveInterest;
    }
}
