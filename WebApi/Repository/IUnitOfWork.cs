namespace WebApi.Repository;

public interface IUnitOfWork
{
    IPostRepository PostRepository { get; }
    IUserRepository UserRepository { get; }
    Task Commit();
}
