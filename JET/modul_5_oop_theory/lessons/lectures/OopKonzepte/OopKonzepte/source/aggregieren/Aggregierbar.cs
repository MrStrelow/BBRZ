﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

internal interface Aggregierbar<T> : Summierbar<T>, Multiplizierbar<T>
{
    // empty
}