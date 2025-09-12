using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

public class JsonUserRepository : IUserRepository
{
    private const string DbFile = "../../../user_database.json";


    // Liest und schreibt nun asynchron
    private async Task<List<User>> LoadUsersAsync()
    {
        if (!File.Exists(DbFile)) return new List<User>();
        string json = await File.ReadAllTextAsync(DbFile);
        
        await Task.Delay(2000);

        return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
    }

    private async Task SaveUsersAsync(List<User> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);

        await Task.Delay(2000);

        await File.WriteAllTextAsync(DbFile, json);
    }

    public async Task AddUserAsync(User newUser)
    {
        var users = await LoadUsersAsync();
        newUser.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
        users.Add(newUser);
        await SaveUsersAsync(users);
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var users = await LoadUsersAsync();
        return users.FirstOrDefault(u => u.Id == id);
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await LoadUsersAsync();
    }
}