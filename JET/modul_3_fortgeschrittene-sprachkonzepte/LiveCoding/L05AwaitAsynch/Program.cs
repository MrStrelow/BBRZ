using Asynch;

internal class Programm
{
    // Schritt 1 - void auf asynch Task umbenennen
    public static async Task Main(string[] args)
    {
        var userService = new UserService();

        var newUser = new UserDTO { Id = 1, Name = "Lax Luster", Email = "lax@luster.lom" };
        
        await userService.SaveUserAsync(newUser);
        Console.WriteLine("--- Operation abgeschlossen, lade zur Kontrolle ---");

        var loadedUser = await userService.LoadUserAsync();

        Console.WriteLine($"Geladener Benutzer: {loadedUser.Name} ({loadedUser.Email})");
        
        Console.WriteLine("\nDrücke eine Taste zum Beenden.");
        Console.ReadKey();
    }
}
