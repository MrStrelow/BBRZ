namespace RepositoryPattern;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(int id);
    Task<IEnumerable<User>> GetAllUsersAsync();
}