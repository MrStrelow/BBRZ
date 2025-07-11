using RepositoryPattern;

IUserRepository repository = new JsonUserRepository();
var userService = new UserService(repository);

// wir waten bis jede zeile fertig ist. im hintergrund hat der thread jedoch spielraum neues zu berechnen.
// Beide tasks können z.B. in einem Thread abgehandelt werden ohne nutzlos zu warten.
//await userService.AddUserAsync(new User { Name = "Anna", Email = "anna@test.com" });
//await userService.AddUserAsync(new User { Name = "Ben", Email = "ben@test.com" });

// vs. 
// gleichzeit
await userService.AddUserAsync(new User { Name = "Anna", Email = "anna@test.com" });
await userService.AddUserAsync(new User { Name = "Ben", Email = "ben@test.com" });

Console.WriteLine("\n--- Suche gestartet ---");
var userId2Task = userService.GetUserByIdAsync(2);
var userId1Task = userService.GetUserByIdAsync(1);

await Task.WhenAll(userId1Task, userId2Task);

var userId2 = await userId2Task ?? throw new NullReferenceException(":(");
var userId1 = await userId1Task ?? throw new NullReferenceException(":(");

var users = new List<User> { userId1, userId2 };

if (users.All( user => user is not null))
{
    users.ForEach( user => Console.WriteLine($"Gefunden: {user.Name} ({user.Email})") );
}
