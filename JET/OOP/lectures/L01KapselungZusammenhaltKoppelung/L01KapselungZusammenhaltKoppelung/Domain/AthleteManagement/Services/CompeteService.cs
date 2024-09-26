using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class CompeteService<T> where T : ICompetitor<T>
{

    private ICollection<T> Competitors = new List<T>();

    public CompeteService(T firstCompetitor, params T[] competitors)
    {
        Competitors.Add(firstCompetitor);

        competitors.ToList().ForEach(comp => Competitors.Add(comp));
    }

    public T Compete(T firstCompetitor, T secondCompetitor)
    {
        return firstCompetitor.Compete(secondCompetitor);
    }

}
