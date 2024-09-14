using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // Aktivkonto - Zugänge im Soll, Abgänge im Haben
    public class Aktivkonto : Konto
    {
        public Aktivkonto(string bezeichnung) : base(bezeichnung) { }

        public override void Buchen(Zugang zugang)
        {
            Soll.Add(zugang); // Zugang auf Aktivkonto -> Soll
        }

        public override void Buchen(Abgang abgang)
        {
            Haben.Add(abgang); // Abgang auf Aktivkonto -> Haben
        }
    }
}
