using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern;

public interface IUserService
{
    Task<UserDTO> FindeUserWelcherAusNewYorkIstUndAmMeistenAusgegebenHat();
    Task<UserDTO> FindeUserWelcherAusNewYorkIstUndAmWenigstenAusgegebenHat();

}
