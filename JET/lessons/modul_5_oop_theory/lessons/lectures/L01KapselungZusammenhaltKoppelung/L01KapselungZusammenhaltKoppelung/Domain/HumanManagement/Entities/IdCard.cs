﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class IdCard : Authentication
{
    public IdCard(string id) : base(id)
    {
        Console.WriteLine($"ich habe zugriff auf {Id}");
        Console.WriteLine($"und kann es manipulieren {Id}");
    }
}
