using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class TennisMatch<T> : Match<T> where T : ICompetitor<T>
{
    public TennisMatch(T firstOpponent, T secondOpponent, params T[] opponents) : base(firstOpponent, secondOpponent, opponents)
    {
    }

    public override T Compete()
    {
        Console.WriteLine("Competing in tennis");
        var first = Opponents.ElementAt(0);
        var second = Opponents.ElementAt(1);

        var resultFirst = first.Compete(second);
        var resultSecond = second.Compete(first);

        if (resultFirst.Equals(resultSecond))
        {
            return resultFirst;
        }
        else if (resultSecond.Equals(resultFirst))
        {
            return resultSecond; 
        }
        else {
            return Opponents.ElementAt(new Random().Next(0, 2));
        }

    }
}
