namespace RepositoryPattern;

public class Programm
{
    public static async Task Main(string[] args)
    {
        // Zuerst das Repository erstellen
        IUserRepository repository = new JsonUserRepository();

        // Dann den Service mit dem Repository instanziieren
        var userService = new UserService(repository);

        var newUser = new User { Id = 1, Name = "Max Mustermann", Email = "max@test.com" };

        await userService.SaveUserAsync(newUser);

        Console.WriteLine("\n----------------\n");

        var loadedUser = await userService.LoadUserAsync();

        Console.WriteLine($"\nGeladener Benutzer: {loadedUser.Name} ({loadedUser.Email})");
        Console.ReadKey();
    }
}
