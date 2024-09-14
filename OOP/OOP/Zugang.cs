using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Zugang : Fluss
    {
        public Zugang(decimal betrag) : base(betrag)
        {
        }

        public override string ToString()
        {
            return $"Zugang: {Betrag:C}";
        }
    }
}
