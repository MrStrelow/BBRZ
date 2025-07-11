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
        //string json = JsonConvert.SerializeObject(user); // {"Id":1,"Name":"Lax Luster","Email":"lax@luster.lom"}
        string json = JsonConvert.SerializeObject(user, Formatting.Indented); // schöner

        // Simulieren wartezeit
        Thread.Sleep(2000);

        File.WriteAllText("../../../database.json", json);
        Console.WriteLine("Benutzer erfolgreich gespeichert!");

    }

    public UserDTO LoadUser()
    {
        Console.WriteLine("Lade Benutzer... (dauert 2 Sekunden)");
        string json = File.ReadAllText("../../../database.json");
        
        // Simulieren wartezeit
        Thread.Sleep(2000);

        Console.WriteLine("Benutzer erfolgreich geladen!");
        return JsonConvert.DeserializeObject<UserDTO>(json);

    }
}
