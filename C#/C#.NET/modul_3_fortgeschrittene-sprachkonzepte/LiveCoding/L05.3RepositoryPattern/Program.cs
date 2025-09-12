using Newtonsoft.Json;

namespace RepositoryPattern;

internal class Programm
{
    static async Task Main(string[] args)
    {
        IUserRepository userRepo = new JsonUserRepository();
        IDataRepository dataRepo = new JsonDataRepository();

        var userService = new UserService(dataRepo, userRepo);
        var bigUser = await userService.FindeUserWelcherAusNewYorkIstUndAmMeistenAusgegebenHat();
        var smallUser = await userService.FindeUserWelcherAusNewYorkIstUndAmWenigstensAusgegebenHat();

        Console.WriteLine($"Gewünschter Benutzer - max: {bigUser.Name} ({smallUser.Stadt})");
        Console.WriteLine($"Gewünschter Benutzer - min: {smallUser.Name} ({bigUser.Stadt})");
    }
}
