using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

// TODO: Untertypbeziehung: FanClub ist ein SportClub? nein.
// Beide besitzen verschiedene Aufgaben.

// TODO:
// Kann ein Athlete ein Fan sein? ja mit neuem untertyp. aber... problem -> neue lösung decorator pattern.

// TODO:
// covariantes problem: verwende Generics hier für verschiedene Fan Clubs.
internal class FanClub<T> where T : ICompetitor<T>
{
    public IFan Organiser { get; set; }

    // TODO: hier dependency injection.
    public ICollection<IFan> Members { get; } = new List<IFan>();

    public ICollection<Event<T>> EventsToCheer { get; } = new List<Event<T>>();

    public FanClub(IFan organiser, IFan firstFan, params IFan[] fans)
    {
        Organiser = organiser;
        Members.Add(firstFan);

        foreach (var item in fans)
        {
            Members.Add(item);
        }
    }

    public void CoordinatedCheer(Match<T> match)
    { 

        foreach (var fan in Members) 
        {
            Console.WriteLine($"Fan: {fan} is '{fan.Cheer()}' is cheering on Player: {match.Opponents.First()}");
        }
    }

    // TODO: observable pattern
    public void CoordinatedBoo()
    {

    }

    private ICompetitor<T> findCompetitorToCheer(Match<T> match)
    {
        //match.Opponents.All(competitor => competitor.);
        // TODO!
        return null;
    }
}
