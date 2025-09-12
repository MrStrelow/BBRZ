using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

internal class BinaereZahl : Zahl
{ 
    public BinaereZahl(String wert)
    {
        Wert = wert;
    }


    public override Zahl sum(Zahl zahl)
    {
        return ((InterneZahlSum) zahl).sumBinaer(this);
    }

    public override Zahl mult(Zahl zahl)
    {
        return ((InterneZahlSum)zahl).sumBinaer(this);
    }


    // Interne Methoden

    protected override Zahl sumDezimal(DezimaleZahl zahl)
    {
        // wandle ich NICHT hier um, sondern so fürh wie möglich, bricht mein system zusammen und ich brauche nicht die double dispatch methoden!
        return new BinaereZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl sumBinaer(BinaereZahl zahl)
    {
        return new BinaereZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl multDezimal(DezimaleZahl zahl)
    {
        return new BinaereZahl((decimal.Parse(zahl.Wert) * decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl multBinaer(BinaereZahl zahl)
    {
        return new BinaereZahl((decimal.Parse(zahl.Wert) * decimal.Parse(this.Wert)).ToString());
    }


    public override void writeToDisk()
    {
        Console.WriteLine("binary");
    }
}
