using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Asynch;

internal class UserService
{
    public async Task SaveUserAsync(UserDTO user)
    {
        Console.WriteLine("Speichere Benutzer... (dauert 2 Sekunden)");
        //string json = JsonConvert.SerializeObject(user); // {"Id":1,"Name":"Lax Luster","Email":"lax@luster.lom"}
        string json = JsonConvert.SerializeObject(user, Formatting.Indented); // schöner

        // Simulieren wartezeit
        await Task.Delay(2000);

        await File.WriteAllTextAsync("../../../database.json", json);
        Console.WriteLine("Benutzer erfolgreich gespeichert!");

    }

    public async Task<UserDTO> LoadUserAsync()
    {
        Console.WriteLine("Lade Benutzer... (dauert 2 Sekunden)");
        string json = await File.ReadAllTextAsync("../../../database.json");
        
        // Simulieren wartezeit
        await Task.Delay(2000);

        Console.WriteLine("Benutzer erfolgreich geladen!");
        return JsonConvert.DeserializeObject<UserDTO>(json);

    }
}
