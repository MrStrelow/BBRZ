using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal class JsonUserRepository : IUserRepository
{
    private string _path = "../../../userresults.json";

    public async Task AddUsersAsync(List<UserDTO> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        await File.WriteAllTextAsync(_path, json);
    }

    public async Task<IEnumerable<UserDTO>?> GetAllUsersAsync()
    {
        string json = await File.ReadAllTextAsync(_path);
        return JsonConvert.DeserializeObject<List<UserDTO>>(json);
    }

    public async Task<UserDTO?> GetByUserIdAsync(int id)
    {
        var users = await GetAllUsersAsync();

        if (users is not null)
            return users.First(user => user.Id == id);
        else
            throw new Exception(":(");
    }
}
