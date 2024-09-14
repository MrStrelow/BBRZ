using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte
{
    internal class BinaereZahl : Zahl
    { 
        public BinaereZahl(String wert)
        {
            Wert = wert;
        }


        public override Zahl sum(Zahl zahl)
        {
            Console.WriteLine("ich summiere in der BinaryZahl");
            return ((IZahl) zahl).sumBinaer(this);
        }

        protected override Zahl sumDezimal(DezimaleZahl zahl)
        {
            return new BinaereZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
        }

        protected override Zahl sumBinaer(BinaereZahl zahl)
        {
            return new BinaereZahl((decimal.Parse(zahl.Wert) + decimal.Parse(this.Wert)).ToString());
        }

        public override void writeToDisk()
        {
            Console.WriteLine("binary");
        }
    }
}
