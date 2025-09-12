using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asynch;

internal class UserService
{
    public async Task SaveUsersAsync(List<UserDTO> users)
    {
        Console.WriteLine("Speichere Benutzer... (dauert 2 Sekunden)");
        //string json = JsonConvert.SerializeObject(users); // {"Id":1,"Name":"Lax Luster","Email":"lax@luster.lom"}
        string json = JsonConvert.SerializeObject(users, Formatting.Indented); // schöner

        // Simulieren wartezeit
        await Task.Delay(2000);

        await File.WriteAllTextAsync("../../../database.json", json);
        Console.WriteLine("Benutzer erfolgreich gespeichert!");

    }

    public async Task SaveUserAsync(UserDTO user)
    {
        Console.WriteLine("Speichere Benutzer... (dauert 2 Sekunden)");
        //string json = JsonConvert.SerializeObject(users); // {"Id":1,"Name":"Lax Luster","Email":"lax@luster.lom"}
        string json = JsonConvert.SerializeObject(user, Formatting.Indented); // schöner

        // Simulieren wartezeit
        await Task.Delay(2000);

        await File.WriteAllTextAsync("../../../database.json", json);
        Console.WriteLine("Benutzer erfolgreich gespeichert!");

    }

    public async Task<UserDTO?> LoadUserAsync()
    {
        Console.WriteLine("Lade Benutzer... (dauert 2 Sekunden)");
        string json = await File.ReadAllTextAsync("../../../database.json");

        // Simulieren wartezeit
        await Task.Delay(2000);

        Console.WriteLine("Benutzer erfolgreich geladen!");
        return JsonConvert.DeserializeObject<UserDTO>(json);
    }

    public async Task<List<UserDTO>?> LoadUsersAsync()
    {
        Console.WriteLine("Lade Benutzer... (dauert 2 Sekunden)");
        string json = await File.ReadAllTextAsync("../../../database.json");

        // Simulieren wartezeit
        await Task.Delay(2000);

        Console.WriteLine("Benutzer erfolgreich geladen!");
        return JsonConvert.DeserializeObject<List<UserDTO>>(json);
    }

    public async Task<UserDTO> LoadUserByIdAsync(int id)
    {
        Console.WriteLine($"Service: Suche Benutzer mit ID {id}...");

        var users = await LoadUsersAsync();

        if (users is not null)
            return users.First(user => user.Id == id);
        else
            throw new Exception(":(");
    }
}
