namespace Hunde;

public class HundeBesitzer : Mensch // Ist-Beziehungen
{
    // private Felder
    private bool _hatHundeFuehrerschein;
    private int _capacity;

    // Hat-Beziehungen
    private Hund[] _hunde;

    // Konstruktoren
    // 1. Konstruktor
    public HundeBesitzer (
        string name, double happiness, int age, 
        bool hatHundeFuehrerschein, int capacity
    ) : base (name, happiness, age) // aufruf des konstruktors des Menschen -> das ist die Basisklasse.
    {
        // setzen der felder aus den parametern des konstruktors.
        _hunde = new Hund[capacity];
        _hatHundeFuehrerschein = hatHundeFuehrerschein;
        _capacity = capacity;
        SetDarstellung("😁");
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
        for (int i = 0; i < hunde.Length; i++)
        {
            _hunde[i] = hunde[i];
        }
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

        foreach (Hund hund in _hunde)
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
        foreach (var hund in _hunde)
        {
            if (hund is not null)
            {
                hund.Fressen(essen);
            }
        }
    }

    public void Buersten()
    {
        foreach (var hund in _hunde)
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
        // ❌ unerwünschte Zustände
        if (!BesitztHund(hund))
        {
            Console.WriteLine($"Hund: {hund} kann nicht ausgesetzt werden, da dieser nicht von {this} besitzt wird.");
            return;
        }

        // ✅ gewünschte Zustände
        for (int i = 0; i < _hunde.Length; i++)
        {
            if (_hunde[i] is not null && _hunde[i] == hund)
            {
                _hunde[i] = null;
            }
        }

        hund.SetBesitzer(null);
    }

    public void Finden(Hund neuerHund)
    {
        // ❌ unerwünschte Zustände
        if (neuerHund is SchaeferHund neuerSchaeferHund && !_hatHundeFuehrerschein)
        {
            Console.WriteLine($"Fehler! Es wird für einen {neuerSchaeferHund.GetType()} ein Hundeführerschein benötigt.");
            return;
        }

        // ✅ gewünschte Zustände
        Console.WriteLine($"Der Hund {neuerHund} wurde von {this} gefunden.");
        neuerHund.SetBesitzer(this);
    }

    public void Kaufen(Hund neuerHund)
    {
        // ❌ unerwünschte Zustände
        if (neuerHund is SchaeferHund neuerSchaeferHund && !_hatHundeFuehrerschein)
        {
            Console.WriteLine($"Fehler! Es wird für einen {neuerSchaeferHund.GetType()} ein Hundeführerschein benötigt.");
            return;
        }

        // ✅ gewünschte Zustände
        Console.WriteLine($"Der Hund {neuerHund} wurde von {this} erworben.");
        neuerHund.SetBesitzer(this);
    }

    public void Verkaufen(Hund hund, HundeBesitzer neuerBesitzer)
    {
        // ❔ unwünschte Zustände werden in den aufgerufenen Methoden bereits abgefragt.
        Aussetzen(hund); 
        neuerBesitzer.Kaufen(hund); // ohne dem entfernen des hundes zuerst aus der liste ist ein hinzufügen zu einem anderen Besitzer nicht möglich.
        Console.WriteLine($"Der Hund {hund} wurde von {this} verkauft und von {neuerBesitzer} erworben.");
    }

    // Get-und-Set-Methoden
    public Hund[] GetHunde()
    {
        return _hunde;
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
        _hunde[position] = hund;
        hund.SetBesitzer(this);
    }

    // Hilfsmethoden
    public bool BesitztHund(Hund hund)
    {
        foreach (var h in _hunde)
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
        for (int i = 0; i < _hunde.Length; i++)
        {
            if (_hunde[i] is null)
            {
                return i;
            }
        }

        return -1;
    }
}

