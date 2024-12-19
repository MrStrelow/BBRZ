namespace Hunde;

public class HundeBesitzer : Mensch // Ist-Beziehungen
{
    // private Felder
    private bool hatHundeFuehrerschein;
    private int capacity;

    // Hat-Beziehungen
    private Hund[] hunde;

    // Konstruktoren
    public HundeBesitzer(string name, double happiness, int age, bool hatHundeFuehrerschein, int capacity)
        : base(name, happiness, age)
    {
        this.hunde = new Hund[capacity];
        this.hatHundeFuehrerschein = hatHundeFuehrerschein;
        this.capacity = capacity;
    }

    public HundeBesitzer(
        Mensch istBaldHundebesitzer, bool hatHundeFuehrerschein, Hund[] hunde, int capacity
    )
        : this(
              istBaldHundebesitzer.GetName(), istBaldHundebesitzer.GetHappiness(), 
              istBaldHundebesitzer.GetAlter(), hatHundeFuehrerschein, capacity)
    {
    }

    public HundeBesitzer(Mensch istBaldHundebesitzer, bool hatHundeFuehrerschein, int capacity)
        : this(
              istBaldHundebesitzer.GetName(), istBaldHundebesitzer.GetHappiness(), 
              istBaldHundebesitzer.GetAlter(), hatHundeFuehrerschein, capacity)
    {
    }

    // Methoden
    public void GassiGehen()
    {
        System.Console.WriteLine($"Ich: {this.GetName()} geh mit...");

        foreach (var hund in hunde)
        {
            if (hund is not null)
            {
                System.Console.WriteLine(hund.GetName());
            }
        }

        System.Console.WriteLine(" gassi.");
    }

    public void Fuettern()
    {
        foreach (var hund in hunde)
        {
            if (hund is not null)
            {
                hund.Fressen(Essen.Fleisch);
            }
        }
    }

    public void Buersten()
    {
        foreach (var hund in hunde)
        {
            if (hund is Pudel pudel)
            {
                pudel.SetHealth(hund.GetHealth() + 10);
                pudel.SetFluff(pudel.GetFluff() * 2);
            }
            else if (hund is not null)
            {
                hund.SetHealth(hund.GetHealth() + 1);
            }
        }
    }

    public void Aussetzen(Hund hund)
    {
        for (int i = 0; i < hunde.Length; i++)
        {
            if (hunde[i] is not null && hunde[i].Equals(hund))
            {
                hunde[i] = null;
            }
        }
    }

    public void Finden(Hund neuerHund)
    {
        neuerHund.SetBesitzer(this);
    }

    public void Kaufen(Hund neuerHund)
    {
        if (neuerHund is SchaeferHund && !hatHundeFuehrerschein)
        {
            System.Console.WriteLine($"Fehler! Es wird für einen {neuerHund.GetType()} ein Hundeführerschein benötigt.");
        }

        neuerHund.SetBesitzer(this);
    }

    public void Verkaufen(Hund hund)
    {
        Aussetzen(hund);
        hund.SetBesitzer(null);
    }

    // Get-und-Set-Methoden
    public Hund[] GetHunde()
    {
        return hunde;
    }

    public void AddHund(Hund hund)
    {
        if (hund is not null && !BesitztHund(hund))
        {
            int key = HabePlatz();

            if (key >= 0)
            {
                hunde[key] = hund;
            }
            else
            {
                System.Console.WriteLine("Bin voll :(");
            }
        }
    }

    // Hilfsmethoden
    public bool BesitztHund(Hund hund)
    {
        foreach (var h in hunde)
        {
            if (h == hund)
            {
                return true;
            }
        }

        return false;
    }

    private int HabePlatz()
    {
        for (int i = 0; i < hunde.Length; i++)
        {
            if (hunde[i] is null)
            {
                return i;
            }
        }

        return -1;
    }
}

