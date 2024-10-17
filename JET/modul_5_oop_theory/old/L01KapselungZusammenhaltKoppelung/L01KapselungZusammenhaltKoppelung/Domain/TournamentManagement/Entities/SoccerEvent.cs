using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class SoccerEvent<T> : Event<T> where T : ICompetitor<T>
{
    // TODO: soccer event is a team round and after that a knock out.
    public SoccerEvent(Schedule<T> schedule) : base(schedule)
    { 

    }

    public override void Start()
    {
        Console.WriteLine("Soccer Event starts: ");

        foreach (var item in Schedule.getAllCompetitors())
        {
            Console.WriteLine(item.Compete());
        }
    }
}
