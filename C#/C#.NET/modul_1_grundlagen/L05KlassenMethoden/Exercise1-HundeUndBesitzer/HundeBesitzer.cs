namespace Hunde;

public class HundeBesitzer : Mensch // Ist-Beziehungen
{
    // private Felder
    private bool _hatHundeFuehrerschein;
    private int _capacity;
    private string _darstellung = "☺️";

    // Hat-Beziehungen
    private Hund[] hunde;

    // Konstruktoren
    // 1. Konstruktor
    public HundeBesitzer (
        string name, double happiness, int age, 
        bool hatHundeFuehrerschein, int capacity
    ) : base (name, happiness, age) // aufruf des konstruktors des Menschen -> das ist die Basisklasse.
    {
        // setzen der felder aus den parametern des konstruktors.
        hunde = new Hund[capacity];
        _hatHundeFuehrerschein = hatHundeFuehrerschein;
        _capacity = capacity;
    }

    // 2. Konstruktor
    public HundeBesitzer (
        Mensch istBaldHundebesitzer, bool hatHundeFuehrerschein, 
        Hund[] hunde, int capacity
    ) : this ( // aufruf eines anderen Konstruktors aus dieser Klasse.
            istBaldHundebesitzer.GetName(), istBaldHundebesitzer.GetHappiness(), 
            istBaldHundebesitzer.GetAlter(), hatHundeFuehrerschein, capacity
        )
    {
        // keine weiteren aufrufe notwendig, da es bereits in einem anderen Konstruktor definiert ist.
    }

    // 3. Konstruktor
    public HundeBesitzer (
        Mensch istBaldHundebesitzer, bool hatHundeFuehrerschein, int capacity
    ) : this (
            istBaldHundebesitzer.GetName(), istBaldHundebesitzer.GetHappiness(), 
            istBaldHundebesitzer.GetAlter(), hatHundeFuehrerschein, capacity
        )
    {
    }

    // Methoden
    public void GassiGehen()
    {
        Console.WriteLine($"Ich: {this} geh mit...");

        foreach (Hund hund in hunde)
        {
            if (hund is not null)
            {
                System.Console.WriteLine(hund);
            }
        }

        System.Console.WriteLine(" gassi.");
    }

    public void Fuettern(Essen essen)
    {
        foreach (var hund in hunde)
        {
            if (hund is not null)
            {
                hund.Fressen(essen);
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

        hund.SetBesitzer(null);
    }

    public void Finden(Hund neuerHund)
    {
        Console.WriteLine($"Der Hund {neuerHund} wurde von {this} erworben.");
        neuerHund.SetBesitzer(this);
    }

    public void Kaufen(Hund neuerHund)
    {
        if (neuerHund is SchaeferHund neuerSchaeferHund && !_hatHundeFuehrerschein)
        {
            Console.WriteLine($"Fehler! Es wird für einen {neuerSchaeferHund.GetType()} ein Hundeführerschein benötigt.");
            return;
        }

        Console.WriteLine($"Der Hund {neuerHund} wurde von {this} erworben.");
        neuerHund.SetBesitzer(this);
    }

    public void Verkaufen(Hund hund, HundeBesitzer neuerBesitzer)
    {
        Aussetzen(hund); // Wir haben das suchen und entfenrnen aus der liste schon in Aussetzen implementiert. Ob das eine gute idee ist, werden wir in Modul 2 bzw. Modul 5 besprechen.
        Console.WriteLine($"Der Hund {hund} wurde von {this} verkauft und von {neuerBesitzer} erworben.");
    }

    // Get-und-Set-Methoden
    public Hund[] GetHunde()
    {
        return hunde;
    }

    public void AddHund(Hund hund)
    {
        // ❌ unerwünschte Zustände
        if (hund is null)
        {
            Console.WriteLine($"Der Parameter hund in AddHund ist null.");
            return;
        }

        if (BesitztHund(hund))
        {
            Console.WriteLine($"Hund {hund} wird bereits von {this} besessen!");
            return; 
        }

        int position = WoHabeIchPlatz();

        if (position < 0)
        {
            Console.WriteLine($"Hundebesitzer {this} hat seine seine Kapazität-{_capacity}- an Hunden überschritten.");
            return;
        }

        // ✅ gewünschte Zustände
        hunde[position] = hund;
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

    private int WoHabeIchPlatz()
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

    public override string GetDarstellung()
    {
        return _darstellung;
    }
}

