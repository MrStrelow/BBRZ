﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

abstract class Athlete : Human
{
    public Athlete(PersonalInformation data, Authentication id) : base(data, id)
    {
    }
}
