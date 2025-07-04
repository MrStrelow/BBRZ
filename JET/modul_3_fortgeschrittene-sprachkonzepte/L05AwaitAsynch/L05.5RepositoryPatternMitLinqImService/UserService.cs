using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal class UserService : IUserService
{
    private IDataRepository _dataRepo;
    private IUserRepository _userRepo;

    public UserService(IDataRepository dataRepo, IUserRepository userRepo)
    {
        _dataRepo = dataRepo;
        _userRepo = userRepo;
    }

    public async Task<UserDTO> FindeUserWelcherAusNewYorkIstUndAmMeistenAusgegebenHat()
    {
        // 1 rufen repo auf um daten zu laden.
        var data = await _dataRepo.LoadJoinedData();
        var city = "New York";

        var result = data.
            Where(d => d.City == city).
            GroupBy(d => d.CustomerID).
            Select(gruppe => new
            {
                UserID = gruppe.Key, // Namen verloren :(
                Name = gruppe.First().Name, // Das ist gefährlich! Name kann verschieden sein, denn es ist nicht teil des Keys!
                                            // Wir nehmen es hier aber an, da wir nur den Nutzen von First() in einer Gruppe zeigen wollen.
                                            // Wir können damit ein beispielhaftes Element aus der Gruppe nehmen und mit z.B. First is es das Erste.
                Umsatz = gruppe.Sum(d => d.Amount)
            }).
            //Max(d => d.Umsatz); // Achtung! gib maximalen umsatz zurück -> Zahl
            MaxBy(d => d.Umsatz); // Achtung! gibt user mit maximalen umsatz zurück -> User

        var userToSave = new UserDTO { Id = result.UserID, Name = result.Name, Stadt = city };
        await _userRepo.AddUsersAsync(new List<UserDTO> { userToSave });

        return userToSave;
    }

    // IDEE: Verwende Func um als Parameter min oder max zu verwenden! Aber dazu später.
    public async Task<UserDTO> FindeUserWelcherAusNewYorkIstUndAmWenigstenAusgegebenHat()
    {
        // 1 rufen repo auf um daten zu laden.
        var data = await _dataRepo.LoadJoinedData();
        var city = "New York";

        var result = data.
            Where(d => d.City == city).
            GroupBy(d => d.CustomerID).
            Select(gruppe => new
            {
                UserID = gruppe.Key,
                Name = gruppe.First().Name,
                Umsatz = gruppe.Sum(d => d.Amount)
            }).
            MinBy(d => d.Umsatz);

        var userToSave = new UserDTO { Id = result.UserID, Name = result.Name, Stadt = city };
        await _userRepo.AddUsersAsync(new List<UserDTO> { userToSave });

        return userToSave;
    }
}
