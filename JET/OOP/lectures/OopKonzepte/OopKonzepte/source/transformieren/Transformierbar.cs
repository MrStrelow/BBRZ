﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopKonzepte;

internal interface Transformierbar<T>
{
    T to(T zahl);
}