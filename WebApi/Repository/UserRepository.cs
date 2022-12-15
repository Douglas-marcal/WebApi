using WebApi.Context;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> GetUsersPosts()
    {
        return await Get().Include(x => x.Posts).ToListAsync();
    }

    public async Task<User> CheckIfUserExistsByEmail(string email)
    {
        return await GetByCondition((user) => user.Email!.Equals(email));
    }
}
