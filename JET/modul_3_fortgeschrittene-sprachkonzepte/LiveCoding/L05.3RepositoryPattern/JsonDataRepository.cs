using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal class JsonDataRepository : IDataRepository
{
    public async Task<IEnumerable<JoinedData>?> LoadJoinedData()
    {
        string json = await File.ReadAllTextAsync("../../../data.json");
        return JsonConvert.DeserializeObject<List<JoinedData>>(json);
    }
}
