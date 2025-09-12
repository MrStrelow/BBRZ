using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCodingKlassen;

public class SchaeferHunde : Hund
{
    // Felder
    public int capacity;

    // Hat - Beziehungen
    private List<Hund> behueteteHunde;

    // Methoden:
    // - Konstruktor
    public SchaeferHunde(string name, bool chipped, int capacity, List<Hund> zuBehueten) : base(name, chipped)
    {
        this.capacity = capacity;

        if (capacity >= zuBehueten.Count()) {
            behueteteHunde = zuBehueten;
        } else
        {
            Console.WriteLine($"Sorry zu viele Hunde zu hueten. Maximal: {capacity}");
        }
    }

    // - Verhaltensmethoden
    public void Hueten()
    {
        throw new NotImplementedException();
    }

    // - Get-Set Methoden
}
