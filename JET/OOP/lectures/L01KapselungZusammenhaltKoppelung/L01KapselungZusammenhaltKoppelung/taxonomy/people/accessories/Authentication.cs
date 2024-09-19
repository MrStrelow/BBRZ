using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal abstract class Authentication
{
    public string Id { get; protected set; } // or { get; init; } for immutability.

    public Authentication(string id)
    {
        Id = id;
    }
}
