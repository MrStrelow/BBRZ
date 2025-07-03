using asynchron;

public class Program
{
    // Die Main-Methode wird ebenfalls asynchron!
    public static async Task Main(string[] args)
    {
        var userService = new UserService();

        var newUser = new User { Id = 1, Name = "Max Mustermann", Email = "max@test.com" };

        // Wir "erwarten" den Abschluss der Speicheroperation
        await userService.SaveUserAsync(newUser);

        Console.WriteLine("--- Operation abgeschlossen, lade zur Kontrolle ---");

        // Wir "erwarten" das Ergebnis (den Benutzer) der Ladeoperation
        var loadedUser = await userService.LoadUserAsync();

        Console.WriteLine($"Geladener Benutzer: {loadedUser.Name} ({loadedUser.Email})");
        Console.WriteLine("\nDrücke eine Taste zum Beenden.");
        Console.ReadKey();
    }
}