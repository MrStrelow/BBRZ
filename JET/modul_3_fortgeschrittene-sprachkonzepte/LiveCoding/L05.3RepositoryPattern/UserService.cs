using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal class UserService
{
    private IDataRepository _dataRepo;
    private IUserRepository _userRepo;

    public UserService(IDataRepository dataRepo, IUserRepository userRepo)
    {
        _dataRepo = dataRepo;
        _userRepo = userRepo;
    }

    public async Task summeDerVerkaeufeNachStandortGroesser1000()
    {
        var data = await _dataRepo.LoadJoinedData();

        var summeDerVerkaeufeNachStandortGroesser1000 = data.
            GroupBy(d => d.City).
            Select(gruppe => new
            {
                City = gruppe.Key,
                UmsatzProCity = gruppe.Sum(u => u.)
            }).
            Where(umsaetze => umsaetze.UmsatzProStandort > 1000). // Das ist unser HAVING! 
            Select(umsaetze => new
            {
                StandortId = umsaetze.StandortId,
                UmsatzProStandort = $"{umsaetze.UmsatzProStandort:C}"
            });

    }
}
