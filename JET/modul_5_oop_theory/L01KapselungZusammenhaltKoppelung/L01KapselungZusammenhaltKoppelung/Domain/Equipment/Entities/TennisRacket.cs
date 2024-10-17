using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;
internal class TennisRacket : Equipment
{
    public TennisRacketProperties TennisRacketProperties { get; set; }
}

enum TennisRacketProperties
{
    Hard, Medium, Soft
}