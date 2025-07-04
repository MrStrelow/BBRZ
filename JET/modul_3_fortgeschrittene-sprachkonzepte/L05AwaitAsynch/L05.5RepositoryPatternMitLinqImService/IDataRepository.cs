using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal interface IDataRepository
{
    Task<IEnumerable<JoinedDataDTO>?> LoadJoinedData();
}
