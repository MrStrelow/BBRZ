using Synch;

internal class Programm
{
    static void Main(string[] args)
    {
        var userService = new UserService();

        var newUser = new UserDTO { Id = 1, Name = "Lax Luster", Email = "lax@luster.lom" };
        
        userService.SaveUser(newUser);
        Console.WriteLine("--- Operation abgeschlossen, lade zur Kontrolle ---");

        var loadedUser = userService.LoadUser();

        Console.WriteLine($"Geladener Benutzer: {loadedUser.Name} ({loadedUser.Email})");
        
        Console.WriteLine("\nDrücke eine Taste zum Beenden.");
        Console.ReadKey();
    }
}
