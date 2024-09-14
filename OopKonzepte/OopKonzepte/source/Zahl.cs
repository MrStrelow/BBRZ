using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte
{
    abstract class Zahl : IZahl, Summierbar<Zahl>, Writable
    {
        public string Wert { get; set; }

        public abstract Zahl sum(Zahl zahl);

        Zahl IZahl.sumDezimal(DezimaleZahl zahl)
        {
            return sumDezimal(zahl);
        }

        Zahl IZahl.sumBinaer(BinaereZahl zahl)
        {
            return sumBinaer(zahl);
        }

        protected abstract Zahl sumDezimal(DezimaleZahl zahl);
        protected abstract Zahl sumBinaer(BinaereZahl zahl);

        public virtual void writeToDisk()
        {
            Console.WriteLine("Zahl: {1}", Wert);
        }
    }
}
