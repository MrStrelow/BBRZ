namespace Hunde;

public class SchaeferHund : Hund // Ist-Beziehungen
{
    // Eigenschaften (wir haben hier keine Felder):
    public int Capacity { get; private set; }
    public Hund[] BehueteteHunde { get; private set; }

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

        Capacity = capacity;
        BehueteteHunde = behuetendeHunde;
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer, Hund spielFreund
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        this.SetBesitzer(besitzer);
        this.SetSpielFreund(spielFreund);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, HundeBesitzer besitzer
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        this.SetBesitzer(besitzer);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, Hund spielFreund
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        this.SetSpielFreund(spielFreund);
    }

    public SchaeferHund(
        string name, int alter, string geschlecht, double health, bool chipped,
        int capacity, Hund[] behuetendeHunde, Hund spielFreund, HundeBesitzer besitzer
    ) 
        : this(name, alter, geschlecht, health, chipped, capacity, behuetendeHunde)
    {
        this.SetSpielFreund(spielFreund);
        this.SetBesitzer(besitzer);
    }

    // Methoden
    public void Hueten()
    {
        foreach (Hund behueteterHund in BehueteteHunde)
        {
            Console.WriteLine($"Ich: {this.GetName()} behüte {behueteterHund.GetName()}");
        }
    }

    public bool HuetetBereitsHund(Hund hund)
    {
        foreach (Hund behueteterHund in BehueteteHunde)
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
                BehueteteHunde[platz] = hund;
            }
            else
            {
                Console.WriteLine("Bin voll :(");
            }
        }
    }

    public void VerstoesseHund(Hund hund)
    {
        for (int i = 0; i < BehueteteHunde.Length; i++)
        {
            //if (BehueteteHunde[i] != null && BehueteteHunde[i].Equals(hund))
            if (BehueteteHunde[i] is not null && BehueteteHunde[i].Equals(hund))
            {
                BehueteteHunde[i] = null;
                break;
            }
        }
    }

    public int GetCapacity()
    {
        return Capacity;
    }

    public void SetCapacity(int capacity)
    {
        Capacity = capacity;
    }

    // Private Hilfsmethoden
    private int HabePlatz()
    {
        for (int i = 0; i < BehueteteHunde.Length; i++)
        {
            if (BehueteteHunde[i] is null)
            {
                return i;
            }
        }
        return -1;
    }


    // Get-und-Set-Methoden
    // ... gibt es nicht, da hier Properties (Eigenschaften) verwendet werden!
}
