using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks; // Wichtig!

namespace ServicesSeperate;
public class UserService
{
    private const string DbFile = "user_database.json";

    // Liest und schreibt nun asynchron
    private async Task<List<User>> LoadUsersAsync()
    {
        if (!File.Exists(DbFile)) return new List<User>();
        string json = await File.ReadAllTextAsync(DbFile);
        return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
    }

    private async Task SaveUsersAsync(List<User> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        await File.WriteAllTextAsync(DbFile, json);
    }

    public async Task AddUserAsync(User newUser)
    {
        Console.WriteLine("Füge Benutzer hinzu (asynchron)...");
        List<User> users = await LoadUsersAsync();

        await Task.Delay(1000); // Nicht-blockierende Verzögerung

        newUser.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
        users.Add(newUser);
        await SaveUsersAsync(users);
        Console.WriteLine($"Benutzer '{newUser.Name}' mit ID {newUser.Id} hinzugefügt.");
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        Console.WriteLine($"Suche Benutzer mit ID {id} (asynchron)...");
        List<User> users = await LoadUsersAsync();

        await Task.Delay(1000); // Nicht-blockierende Verzögerung

        // LINQ selbst ist synchron und arbeitet im Speicher!
        // Es benötigt kein 'await', da die Daten (users) bereits geladen sind.
        User? foundUser = users.FirstOrDefault(user => user.Id == id);

        if (foundUser != null)
            Console.WriteLine("Benutzer gefunden!");
        else
            Console.WriteLine("Benutzer nicht gefunden.");

        return foundUser;
    }
}