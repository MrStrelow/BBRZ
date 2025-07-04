using Synch;

internal class Programm
{
    static async Task Main(string[] args)
    {
        var userService = new UserService();

        var newUser1 = new UserDTO { Id = 1, Name = "Lax Luster", Email = "lax@luster.lom" };
        var newUser2 = new UserDTO { Id = 2, Name = "Nax Nuster", Email = "Nax@nuster.lom" };
        
        await userService.SaveUsersAsync(new List<UserDTO> { newUser1, newUser2 });
        Console.WriteLine("--- Operation abgeschlossen, lade zur Kontrolle ---");

        var loadedUser1Task = userService.LoadUserByIdAsync(1);
        var loadedUser2Task = userService.LoadUserByIdAsync(2);

        await Task.WhenAll(loadedUser1Task, loadedUser2Task); // warten auf den längsamsten task bis alle fertig sind.
        //Task.WhenAny(loadedUser1, loadedUser2); // hören auf wenn ein task fertig ist.

        var loadedUser1 = await loadedUser1Task;
        var loadedUser2 = await loadedUser2Task;

        Console.WriteLine($"Geladener Benutzer: {loadedUser1.Name} ({loadedUser1.Email})");
        Console.WriteLine($"Geladener Benutzer: {loadedUser2.Name} ({loadedUser2.Email})");
        
        Console.WriteLine("\nDrücke eine Taste zum Beenden.");
        Console.ReadKey();
    }
}
