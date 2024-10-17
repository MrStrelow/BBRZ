using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Passport : Authentication
{
    public string visa {  get; set; }
    public Passport(string id) : base(id)
    {
    }

}
