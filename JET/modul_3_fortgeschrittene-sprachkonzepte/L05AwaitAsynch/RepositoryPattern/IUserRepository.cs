namespace RepositoryPattern;

public interface IUserRepository
{
    Task SaveUserAsync(User user);
    Task<User> GetUserAsync();
}