using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks; // Wichtiges Using!

namespace asynchron;

public class UserService
{
    private const string DatabaseFile = "../../../database.json";

    public async Task SaveUserAsync(User user)
    {
        Console.WriteLine("Speichere Benutzer asynchron... (dauert 2 Sekunden)");
        string json = JsonConvert.SerializeObject(user, Formatting.Indented);

        // Simuliert eine langsame Operation, aber asynchron!
        await Task.Delay(2000);

        await File.WriteAllTextAsync(DatabaseFile, json);
        Console.WriteLine("Benutzer erfolgreich asynchron gespeichert!");
    }

    public async Task<User> LoadUserAsync()
    {
        Console.WriteLine("Lade Benutzer asynchron... (dauert 2 Sekunden)");

        // Simuliert eine langsame Operation, aber asynchron!
        await Task.Delay(2000);

        string json = await File.ReadAllTextAsync(DatabaseFile);
        Console.WriteLine("Benutzer erfolgreich asynchron geladen!");
        return JsonConvert.DeserializeObject<User>(json);
    }
}