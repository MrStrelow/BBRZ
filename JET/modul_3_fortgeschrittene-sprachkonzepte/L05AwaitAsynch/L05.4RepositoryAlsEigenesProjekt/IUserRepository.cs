namespace RepositoryPatternSeperate;

public interface IUserRepository
{
    Task AddUserAsync(UserDTO user);
    Task<UserDTO?> GetUserByIdAsync(int id);
    Task<IEnumerable<UserDTO>> GetAllUsersAsync();
}