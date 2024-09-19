using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

// why is fanclub not a team? Why not use extensions?
// use generics to make a another player to be part of a fanclub?
// or how do we deal with this?
internal class FanClub
{
    public List<Fan> fanclub { get; set; } = new List<Fan>();

    public FanClub(params Fan[] fans)
    {
        foreach (var item in fans)
        {
            fanclub.Add(item);
        }
    }
}
