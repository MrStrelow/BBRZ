using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Place
{
    public Address Address { get; }
    public (decimal longitude, decimal latitude) location;

    public override string ToString()
    {
        return location.ToString();
    }
}
