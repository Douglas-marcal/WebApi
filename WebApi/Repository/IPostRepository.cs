using WebApi.Models;
using WebApi.Pagination;

namespace WebApi.Repository;

public interface IPostRepository : IRepository<Post>
{
    PagedList<Post> GetPosts(PostsParameters produtosParameters);

    Task<IEnumerable<Post>> GetByNewestPosts();
}
