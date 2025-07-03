namespace RepositoryPatternSeperate;

// Alle Usings von oben übernehmen
public class JsonUserRepository : IUserRepository
{
    private const string DbFile = "user_database.json";

    private async Task<List<UserDTO>> LoadUsersAsync() { /* ... wie oben ... */ }
    private async Task SaveUsersAsync(List<UserDTO> users) { /* ... wie oben ... */ }

    public async Task AddUserAsync(UserDTO newUser)
    {
        var users = await LoadUsersAsync();
        newUser.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
        users.Add(newUser);
        await SaveUsersAsync(users);
    }

    public async Task<UserDTO?> GetUserByIdAsync(int id)
    {
        var users = await LoadUsersAsync();
        return users.FirstOrDefault(u => u.Id == id);
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        return await LoadUsersAsync();
    }
}