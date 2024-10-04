using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class TennisEvent<T> : Event<T> where T : ICompetitor<T>
{
    // TODO: tennis event is a knock out from the start.
    public TennisEvent(Schedule<T> schedule) : base(schedule)
    {

    }

    public override void Start()
    {
        Console.WriteLine("Tennis event starts: ");

        //Schedule.getAllCompetitors().ToList().ForEach(Console.WriteLine);
        //Schedule.getAllCompetitors().ToList().ForEach(item => Console.WriteLine(item));

        foreach (var item in Schedule.getAllCompetitors())
        {
            Console.WriteLine(item.Compete());
        }
    }
}
