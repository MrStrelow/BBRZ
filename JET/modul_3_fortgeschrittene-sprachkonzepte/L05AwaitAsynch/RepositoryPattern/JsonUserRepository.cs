using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class JsonUserRepository : IUserRepository
    {
        private const string DatabaseFile = "database.json";

        public async Task SaveUserAsync(User user)
        {
            string json = JsonConvert.SerializeObject(user, Formatting.Indented);
            await Task.Delay(1000); // Simuliert Schreibverzögerung
            await File.WriteAllTextAsync(DatabaseFile, json);
        }

        public async Task<User> GetUserAsync()
        {
            await Task.Delay(1000); // Simuliert Leseverzögerung
            string json = await File.ReadAllTextAsync(DatabaseFile);
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}
