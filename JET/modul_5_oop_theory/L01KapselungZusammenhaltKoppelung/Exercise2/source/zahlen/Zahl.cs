using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

abstract class Zahl : InterneZahl, Aggregierbar<Zahl>, Transformierbar<Zahl>, Speicherbar
{
    public string Wert { get; set; }

    public abstract Zahl sum(Zahl zahl);
    public abstract Zahl mult(Zahl zahl);

    // nicht sichtbar für user


    // Interne Methoden - für Aufruf in unterklassen

    // transformieren
    Zahl Transformierbar<Zahl>.to(Zahl zahl)
    {
        return to(zahl);
    }

    // aggregieren

    Zahl InterneZahlSum.sumDezimal(DezimaleZahl zahl)
    {
        return sumDezimal(zahl);
    }

    Zahl InterneZahlSum.sumBinaer(BinaereZahl zahl)
    {
        return sumBinaer(zahl);
    }

    Zahl InterneZahlMult.multDezimal(DezimaleZahl zahl)
    {
        return multDezimal(zahl);
    }

    Zahl InterneZahlMult.multBinaer(BinaereZahl zahl)
    {
        return multBinaer(zahl);
    }

    // Interne Methoden - zum implementiern
    // transformieren
    protected abstract Zahl to(Zahl zahl);

    // aggregieren
    protected abstract Zahl sumDezimal(DezimaleZahl zahl);
    protected abstract Zahl sumBinaer(BinaereZahl zahl);
    protected abstract Zahl multDezimal(DezimaleZahl zahl);
    protected abstract Zahl multBinaer(BinaereZahl zahl);


    // Speichern
    public virtual void writeToDisk()
    {
        Console.WriteLine("Zahl: {1}", Wert);
    }
}
