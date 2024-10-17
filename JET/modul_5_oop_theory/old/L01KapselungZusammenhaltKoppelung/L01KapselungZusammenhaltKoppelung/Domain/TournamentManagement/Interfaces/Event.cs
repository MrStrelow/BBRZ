using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

// TODO: use Iterator pattern -> an event is iterable.
// We iterate such that event are consistent -> BFS. tree like.
abstract class Event<T> where T : ICompetitor<T>
{
    public Schedule<T> Schedule { get; set; }

    public Event(Schedule<T> schedule)
    {
        Schedule = schedule;
    }

    public virtual void Start()
    {
        Console.WriteLine("event starts");

        //Schedule.getAllCompetitors().ToList().ForEach(Console.WriteLine);
        //Schedule.getAllCompetitors().ToList().ForEach(item => Console.WriteLine(item));

        foreach (var item in Schedule.getAllCompetitors())
        {
            Console.WriteLine(item.Compete());
        }
    }
}
