using asynchron;

public class Program
{
    // Die Main-Methode wird ebenfalls asynchron!
    public static async Task Main(string[] args)
    {
        var userService = new UserService();

        var newUser = new User { Id = 1, Name = "Max Mustermann", Email = "max@test.com" };

        // Wir "erwarten" den Abschluss der Speicheroperation nicht
        await userService.SaveUserAsync(newUser);
        // Wir "erwarten" das Ergebnis (den Benutzer) der Ladeoperation
        var loadedUser = await userService.LoadUserAsync();

        // Wir sind nicht schneller hier als bei synch, aber wir sparen rechenzeit wenn wir komplett ausgelastet wären!
        Console.WriteLine("--- Operation abgeschlossen, lade zur Kontrolle ---");
        Console.WriteLine($"Geladener Benutzer: {loadedUser.Name} ({loadedUser.Email})");
        Console.WriteLine("\nDrücke eine Taste zum Beenden.");
        Console.ReadKey();
    }
}