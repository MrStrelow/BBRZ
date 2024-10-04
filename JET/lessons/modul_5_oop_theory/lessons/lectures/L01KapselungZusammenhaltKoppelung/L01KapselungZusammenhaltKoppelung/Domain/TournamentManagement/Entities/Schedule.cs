using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class Schedule<T> where T : ICompetitor<T>
{
    // TODO: dependency injection
    private IDictionary<DateTime, Match<T>> schedules = new Dictionary<DateTime, Match<T>>();

    // TODO: we could do here sanity checks and stuff.
    public void AddMatch(DateTime date, Match<T> match)
    {
        schedules.Add(date, match);
    }

    public Match<T> getCompetitor (DateTime time)
    {
        return schedules[time];
    }

    public ICollection<Match<T>> getAllCompetitors()
    {
        return schedules.Values;
    }
}
