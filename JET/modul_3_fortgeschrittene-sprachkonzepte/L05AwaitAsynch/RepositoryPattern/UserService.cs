using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks; // Wichtiges Using!

namespace RepositoryPattern;

public class UserService
{
    private readonly IUserRepository _userRepository;

    // Der Service hängt von der Abstraktion, nicht von der Implementierung ab
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task SaveUserAsync(User user)
    {
        Console.WriteLine("Service: Leite Speicheranfrage an Repository weiter...");
        await _userRepository.SaveUserAsync(user);
        Console.WriteLine("Service: Speichern abgeschlossen.");
    }

    public async Task<User> LoadUserAsync()
    {
        Console.WriteLine("Service: Frage Benutzer von Repository an...");
        var user = await _userRepository.GetUserAsync();
        Console.WriteLine("Service: Benutzer erhalten.");
        return user;
    }
}