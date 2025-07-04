using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

internal class JsonUserRepository : IUserRepository
{
    public Task AddUsersAsync(List<UserDTO> user)
    {
        throw new NotImplementedException(); // TODO implement me - siehe 5.2 Service
    }

    public Task<IEnumerable<UserDTO>> GetAllUsersAsync()
    {
        throw new NotImplementedException(); // TODO implement me - siehe 5.2 Service
    }

    public Task<UserDTO?> GetByUserIdAsync(int id)
    {
        throw new NotImplementedException(); // TODO implement me - siehe 5.2 Service
    }
}
