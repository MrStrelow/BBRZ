using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // Passivkonto - Zugänge im Haben, Abgänge im Soll
    public class Passivkonto : Konto
    {
        public Passivkonto(string bezeichnung) : base(bezeichnung) { }

        public override void Buchen(Zugang zugang)
        {
            Haben.Add(zugang); // Zugang auf Passivkonto -> Haben
        }

        public override void Buchen(Abgang abgang)
        {
            Soll.Add(abgang); // Abgang auf Passivkonto -> Soll
        }
    }
}
