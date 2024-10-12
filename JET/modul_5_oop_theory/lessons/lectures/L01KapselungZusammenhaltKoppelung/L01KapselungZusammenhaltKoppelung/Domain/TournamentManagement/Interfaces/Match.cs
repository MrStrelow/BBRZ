using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

// TODO: strategy pattern for... an alternative setup.
// TOOD: then see that the strategy pattern is kinda outdated,
// if one can use funcitonal programming elements such as delegates (Actions) and lambdas in c#
abstract class Match<T> where T : ICompetitor<T>
{
    // TODO: dependency injection
    public ICollection<T> Opponents { get; set; } = new List<T>();

    public Match(T firstOpponent, T secondOpponent, params T[] opponents)
    {
        Opponents.Add(firstOpponent);
        Opponents.Add(secondOpponent);

        foreach (var item in opponents)
        {
            Opponents.Add(item);
        }
    }

    public abstract T Compete();
}
