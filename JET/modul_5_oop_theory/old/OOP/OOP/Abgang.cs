using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    // Klasse für Abgang
    public class Abgang : Fluss
    {
        public Abgang(decimal betrag) : base(betrag)
        {
        }

        public override string ToString()
        {
            return $"Abgang: {Betrag:C}";
        }
    }
}
