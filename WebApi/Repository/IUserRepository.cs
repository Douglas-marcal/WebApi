using WebApi.Models;

namespace WebApi.Repository;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<User>> GetUsersPosts();

    Task<User> CheckIfUserExistsByEmail(string email);
}
