using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class SoccerMatch<T> : Match<T> where T : ICompetitor<T>
{

    public SoccerMatch(T firstOpponent, T secondOpponent, params T[] opponents) : base(firstOpponent, secondOpponent, opponents)
    {
    }

    public override T Compete()
    {
        Console.WriteLine("Competing in soccer");
        return default;
    }
}
