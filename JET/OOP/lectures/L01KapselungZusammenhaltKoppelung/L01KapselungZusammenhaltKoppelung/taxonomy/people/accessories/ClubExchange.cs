using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class ClubExchange
{
    // wollen wir hier ICollection? was ist mit add und get methoden?
    private ICollection<Club> _clubsWithoutCoach = new List<Club>();

    // Methoden überladen
    public ClubExchange(params Club[] clubsWithoutCoach)
    {
        foreach (var item in clubsWithoutCoach)
        {
            _clubsWithoutCoach.Add(item);
        }
    }

    // Methoden überladen
    public ClubExchange(ICollection<Club> clubsWithoutCoach)
    {
        _clubsWithoutCoach = clubsWithoutCoach;
    }

    public void AddclubWithoutCoach(Club club)
    {
        _clubsWithoutCoach.Add(club);
    }

    public Club signContractWithCoach(Trainer coach)
    {
        var position = new Random().Next(0, _clubsWithoutCoach.Count - 1);
        //var chosenClub = _clubsWithoutCoach.OrderBy(x => position).First();
        var chosenClub = _clubsWithoutCoach.ToList()[position];

        Console.WriteLine($"{coach} signed a Contract with {chosenClub}");

        return chosenClub;
    }
}
