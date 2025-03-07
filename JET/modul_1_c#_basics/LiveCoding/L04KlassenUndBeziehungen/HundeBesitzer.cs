using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCodingKlassen;

public class HundeBesitzer : Mensch
{
    // Felder
    private int capacity;
    private bool hatHundeFuehrerschein;

    // Hat - Beziehungen
    private List<Hund> hunde = new List<Hund>();

    // Methoden:
    // - Konstruktor
    public HundeBesitzer(string name, int alter, double happiness, int capacity, Hund meinErsterHund) : base(name, alter, happiness)
    {
        this.capacity = capacity;
        meinErsterHund.SetBesitzer(this);
    }

    // - Verhaltensmethoden

    // - Get-Set Methoden
    public void AddHund(Hund hund)
    {
        hunde.Add(hund);
    }

    public bool BesitztHund(Hund hund)
    {
        return hunde.Contains(hund);
    }
}