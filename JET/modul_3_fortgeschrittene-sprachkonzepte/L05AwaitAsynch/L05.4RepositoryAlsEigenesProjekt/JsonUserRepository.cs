using Newtonsoft.Json;

namespace RepositoryPatternSeperate;

public class JsonUserRepository : IUserRepository
{
    private const string DbFile = "../../../user_database.json";


    // Liest und schreibt nun asynchron
    private async Task<List<UserDTO>> LoadUsersAsync()
    {
        if (!File.Exists(DbFile)) return new List<UserDTO>();
        string json = await File.ReadAllTextAsync(DbFile);

        await Task.Delay(2000);

        return JsonConvert.DeserializeObject<List<UserDTO>>(json) ?? new List<UserDTO>();
    }

    private async Task SaveUsersAsync(List<UserDTO> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);

        await Task.Delay(2000);

        await File.WriteAllTextAsync(DbFile, json);
    }

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