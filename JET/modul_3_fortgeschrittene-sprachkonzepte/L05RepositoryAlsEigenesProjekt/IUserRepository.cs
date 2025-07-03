namespace RepositoryPatternSeperate;

public interface IUserRepository
{
    Task SaveUserAsync(User user);
    Task<User> GetUserAsync();
}