using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Fluss
    {
        public decimal Betrag { get; }

        public Fluss(decimal betrag)
        {
            Betrag = betrag;
        }
    }
}
