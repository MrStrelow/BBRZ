using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace RepositoryPattern;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUserAsync(User user)
    {
        // Hier könnte Business-Logik stehen (z.B. Validierung)
        Console.WriteLine($"Service: Füge '{user.Name}' hinzu...");
        await _userRepository.AddUserAsync(user);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        Console.WriteLine($"Service: Suche Benutzer mit ID {id}...");
        return await _userRepository.GetUserByIdAsync(id);
    }
}