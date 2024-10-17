using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

abstract class Equipment
{
    public Brand Brand { get; set; }
    public Quality Quality { get; set; }
}
