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
    ) 
        : base(name, alter, geschlecht, health, chipped)
    {
        if (capacity < behuetendeHunde.Length)
        {
            return;
        }

        _capacity = capacity;
        _behueteteHunde = behuetendeHunde;
        SetDarstellung("🐕‍🦺");
        SetLautBeimBellen("⬆️Wuff⬆️");
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer, Hund spielFreund
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        SetBesitzer(besitzer);
        SetSpielFreund(spielFreund);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        SetBesitzer(besitzer);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, Hund spielFreund
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
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

    public bool HuetetBereitsHund(Hund hund)
    {
        foreach (Hund behueteterHund in _behueteteHunde)
        {
            if (behueteterHund is not null && behueteterHund.Equals(hund))
            {
                return true;
            }
        }
        return false;
    }

    public void AddZuBehuetendeHunde(Hund hund)
    {
        if (hund is not null && !HuetetBereitsHund(hund))
        {
            int platz = HabePlatz();
            if (platz >= 0)
            {
                _behueteteHunde[platz] = hund;
            }
            else
            {
                Console.WriteLine($"{this} ist am limit seiner Hütfähigkeit-{_capacity}-.");
            }
        }
    }

    public void VerstoesseHund(Hund hund)
    {
        for (int i = 0; i < _behueteteHunde.Length; i++)
        {
            //if (BehueteteHunde[i] != null && BehueteteHunde[i].Equals(hund)) // macht das gleiche
            if (_behueteteHunde[i] is not null && _behueteteHunde[i].Equals(hund))
            {
                _behueteteHunde[i] = null;
                break;
            }
        }
    }

    public int GetCapacity()
    {
        return _capacity;
    }


    // Private Hilfsmethoden
    private int HabePlatz()
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

    // Get-und-Set-Methoden
    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }
}
