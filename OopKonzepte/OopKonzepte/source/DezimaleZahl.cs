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
        return ((IZahl) zahl).sumDezimal(this);
    }

    protected override Zahl sumDezimal(DezimaleZahl zahl)
    {
        return new DezimaleZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
    }

    protected override Zahl sumBinaer(BinaereZahl zahl)
    {
        return new DezimaleZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
    }
}
