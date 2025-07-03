using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace synchron;

public class UserService
{
    private const string DatabaseFile = "database.json";

    // SYNCHRON: Speichert einen Benutzer und blockiert dabei
    public void SaveUser(User user)
    {
        Console.WriteLine("Speichere Benutzer... (dauert 2 Sekunden)");
        string json = JsonConvert.SerializeObject(user, Formatting.Indented);

        // Simuliert eine langsame Festplatte oder ein langsames Netzwerk
        Thread.Sleep(2000);

        File.WriteAllText(DatabaseFile, json);
        Console.WriteLine("Benutzer erfolgreich gespeichert!");
    }

    // SYNCHRON: Lädt einen Benutzer und blockiert dabei
    public User LoadUser()
    {
        Console.WriteLine("Lade Benutzer... (dauert 2 Sekunden)");

        // Simuliert eine langsame Festplatte oder ein langsames Netzwerk
        Thread.Sleep(2000);

        string json = File.ReadAllText(DatabaseFile);
        Console.WriteLine("Benutzer erfolgreich geladen!");
        return JsonConvert.DeserializeObject<User>(json);
    }
}