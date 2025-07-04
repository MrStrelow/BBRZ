using RepositoryPatternSeperate;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddUserAsync(UserDTO user)
    {
        // Hier könnte Business-Logik stehen (z.B. Validierung)
        Console.WriteLine($"Service: Füge '{user.Name}' hinzu...");
        await _userRepository.AddUserAsync(user);
    }

    public async Task<UserDTO?> GetUserByIdAsync(int id)
    {
        Console.WriteLine($"Service: Suche Benutzer mit ID {id}...");
        return await _userRepository.GetUserByIdAsync(id);
    }
}