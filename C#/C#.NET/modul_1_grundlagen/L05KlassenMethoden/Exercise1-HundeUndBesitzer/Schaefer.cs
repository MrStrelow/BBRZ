namespace Hunde;

public class SchaeferHund : Hund // Ist-Beziehungen
{
    // private Felder
    private int _capacity;
    private Hund[] _behueteteHunde;

    // Konstruktoren:
    public SchaeferHund(
        string name, int alter, string geschlecht, double health, 
        bool chipped,int capacity, Hund[] behuetendeHunde
    ) : base(
            name, alter, geschlecht, health, chipped
        )
    {
        if (capacity < behuetendeHunde.Length)
        {
            Console.WriteLine("Capacity passt nicht mit behuetendeHunde zuammen. _capacity auf länge von _behuetendeHunde gesetzt.");
            capacity = behuetendeHunde.Length;
        }

        _capacity = capacity;
        _behueteteHunde = behuetendeHunde;
        SetDarstellung("🐕‍🦺");
        SetLautBeimBellen("⬆️Wuff⬆️");
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer, Hund spielFreund
    ) : this(
            name, alter, geschlecht, health, chipped, capacity, behuetendeHunde
        )
    {
        SetBesitzer(besitzer);
        SetSpielFreund(spielFreund);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer
    ) : this(
            name, alter, geschlecht, health, chipped, capacity, behuetendeHunde
        )
    {
        SetBesitzer(besitzer);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, Hund spielFreund
    ) : this(
            name, alter, geschlecht, health, chipped, capacity, behuetendeHunde
        )
    {
        SetSpielFreund(spielFreund);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, Hund spielFreund, HundeBesitzer besitzer
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        SetSpielFreund(spielFreund);
        SetBesitzer(besitzer);
    }

    // Methoden
    public void Hueten()
    {
        foreach (Hund behueteterHund in _behueteteHunde)
        {
            Console.WriteLine($"Ich: {this} behüte {behueteterHund}");
        }
    }

    public void AddZuBehuetendeHunde(Hund hund)
    {
        // ❌ unerwünschte Zustände
        if (hund is null)
        {
            Console.WriteLine($"Parameter hund ist null bei AddZuBehuetendeHunde.");
            return;
        }

        if (HuetetBereitsHund(hund))
        {
            Console.WriteLine($"Hund-{hund}- wird bereits von {this} behütet.");
            return;
        }

        int platz = WoHabeIchPlatz();
        if (platz < 0)
        {
            Console.WriteLine($"{this} ist am limit seiner Hütfähigkeit-{_capacity}-.");
            return;
        }

        // ✅ gewünschte Zustände
        _behueteteHunde[platz] = hund;
    }

    public void VerstoesseHund(Hund hund)
    {
        for (int i = 0; i < _behueteteHunde.Length; i++)
        {
            //if (BehueteteHunde[i] != null und die Bedingung BehueteteHunde[i].Equals(hund)) macht jetzt noch das gleiche.
            if (_behueteteHunde[i] is not null)
            {
                if (_behueteteHunde[i] == hund)
                {
                    _behueteteHunde[i] = null;
                    break;
                }
            }
        }
    }

    // Private Hilfsmethoden
    private int WoHabeIchPlatz()
    {
        for (int i = 0; i < _behueteteHunde.Length; i++)
        {
            if (_behueteteHunde[i] is null)
            {
                return i;
            }
        }
        return -1;
    }

    // Die Hilfsmethode ist public, da wir in der Main Methode diese fürs Testen verwenden.
    // Solle später dann private werden.
    public bool HuetetBereitsHund(Hund hund)
    {
        foreach (Hund behueteterHund in _behueteteHunde)
        {
            if (behueteterHund is not null && behueteterHund == hund)
            {
                return true;
            }
        }
        return false;
    }

    // Get-und-Set-Methoden
    public int GetCapacity()
    {
        return _capacity;
    }
    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }
}
