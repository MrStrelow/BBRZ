﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Place
{
    // Soll ich den Ort des Busses ändern können von außen?
    // kein set. aber dann brauche ich einen Konstruktor.
    public BuidldingAddress Address { get; set; }

    public override string ToString()
    {
        return Address.location.ToString();
    }
}
