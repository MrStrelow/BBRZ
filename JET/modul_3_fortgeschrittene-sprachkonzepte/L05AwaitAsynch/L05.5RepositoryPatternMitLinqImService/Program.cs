using Newtonsoft.Json;
using RepositoryPattern;

IUserRepository userRepo = new JsonUserRepository();
IDataRepository dataRepo = new JsonDataRepository();

IUserService userService = new UserService(dataRepo, userRepo);
var bigUser = await userService.FindeUserWelcherAusNewYorkIstUndAmMeistenAusgegebenHat();
var smallUser = await userService.FindeUserWelcherAusNewYorkIstUndAmWenigstenAusgegebenHat();

Console.WriteLine($"Gewünschter Benutzer - max: {bigUser.Name} ({smallUser.Stadt})");
Console.WriteLine($"Gewünschter Benutzer - min: {smallUser.Name} ({bigUser.Stadt})");
