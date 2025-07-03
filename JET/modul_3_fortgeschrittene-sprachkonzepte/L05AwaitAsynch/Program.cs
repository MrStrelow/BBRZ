namespace synchron;
public class Program
{
    public static void Main(string[] args)
    {
        var userService = new UserService();

        var newUser = new User { Id = 1, Name = "Max Mustermann", Email = "max@test.com" };

        userService.SaveUser(newUser);

        Console.WriteLine("--- Operation abgeschlossen, lade zur Kontrolle ---");

        var loadedUser = userService.LoadUser();

        Console.WriteLine($"Geladener Benutzer: {loadedUser.Name} ({loadedUser.Email})");
        Console.WriteLine("\nDrücke eine Taste zum Beenden.");
        Console.ReadKey();
    }
}