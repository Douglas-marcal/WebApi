using WebApi.Context;

namespace WebApi.Repository;

public class UnitOfWork : IUnitOfWork
{
    private PostRepository _postRepo;
    private UserRepository _userRepo;
    public AppDbContext _context;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IPostRepository PostRepository
    {
        get
        {
            return _postRepo = _postRepo ?? new PostRepository(_context);
        }
    }

    public IUserRepository UserRepository
    {
        get
        {
            return _userRepo = _userRepo ?? new UserRepository(_context);
        }
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
