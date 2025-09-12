using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal interface IUserRepository
{
    Task AddUsersAsync(List<UserDTO> users);
    Task<UserDTO?> GetByUserIdAsync(int id);
    Task<IEnumerable<UserDTO>?> GetAllUsersAsync(); // IEnumerable ist quasi eine Liste.
}
