using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

internal class DezimaleZahl : Zahl
{
    public DezimaleZahl(String wert)
    {
        Wert = wert;
    }

    public override Zahl sum(Zahl zahl)
    {
        // wandle ich hier um, bricht mein system zusammen und ich brauche nicht die double dispatch methoden!
        return ((InterneZahlSum) zahl).sumDezimal(this);
    }
    public override Zahl mult(Zahl zahl)
    {
        throw new NotImplementedException();
    }

    // Interne Methoden
    // transformieren 
    protected override Zahl to(Zahl zahl)
    {
        this.to(zahl);
    }

    // aggregieren

    protected override Zahl sumDezimal(DezimaleZahl zahl)
    {
        return new DezimaleZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl sumBinaer(BinaereZahl zahl)
    {
        return new DezimaleZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl multDezimal(DezimaleZahl zahl)
    {
        return new DezimaleZahl((decimal.Parse(zahl.Wert) * decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl multBinaer(BinaereZahl zahl)
    {
        return new BinaereZahl((decimal.Parse(zahl.Wert) * decimal.Parse(this.Wert)).ToString());
    }
}
