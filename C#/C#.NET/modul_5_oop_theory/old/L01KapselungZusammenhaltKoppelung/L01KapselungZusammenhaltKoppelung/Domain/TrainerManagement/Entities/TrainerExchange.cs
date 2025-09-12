using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L01KapselungZusammenhaltKoppelung;

internal class TrainerExchange
{
    // wollen wir hier ICollection? was ist mit add und get methoden?
    private ICollection<SportClub> _clubsWithoutCoach = new List<SportClub>();

    // Methoden überladen
    public TrainerExchange(params SportClub[] clubsWithoutCoach)
    {
        foreach (var item in clubsWithoutCoach)
        {
            _clubsWithoutCoach.Add(item);
        }
    }

    // Methoden überladen
    public TrainerExchange(ICollection<SportClub> clubsWithoutCoach)
    {
        _clubsWithoutCoach = clubsWithoutCoach;
    }

    public void AddclubWithoutCoach(SportClub club)
    {
        _clubsWithoutCoach.Add(club);
    }

    public SportClub signContractWithCoach(Trainer coach)
    {
        var position = new Random().Next(0, _clubsWithoutCoach.Count - 1);
        //var chosenClub = _clubsWithoutCoach.OrderBy(x => position).First();
        var chosenClub = _clubsWithoutCoach.ToList()[position];

        Console.WriteLine($"{coach} signed a Contract with {chosenClub}");

        return chosenClub;
    }
}
