using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Synch;

internal class UserService
{
    public void SaveUser(UserDTO user)
    {
        Console.WriteLine("Speichere Benutzer... (dauert 2 Sekunden)");
        string json = JsonConvert.SerializeObject(user, Formatting.Indented);

        // Simulieren wartezeit
        Thread.Sleep(2000);

        File.WriteAllText("../../../database.json", json);
        Console.WriteLine("Benutzer erfolgreich gespeichert!");

    }

    public UserDTO LoadUser(UserDTO user)
    {
        Console.WriteLine("Lade Benutzer... (dauert 2 Sekunden)");
        string json = File.ReadAllText("../../../database.json");
        
        // Simulieren wartezeit
        Thread.Sleep(2000);

        Console.WriteLine("Benutzer erfolgreich geladen!");
        return JsonConvert.DeserializeObject<UserDTO>(json);

    }
}
