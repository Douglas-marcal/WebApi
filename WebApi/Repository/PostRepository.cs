using WebApi.Context;
using WebApi.Models;
using WebApi.Pagination;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository;

public class PostRepository : Repository<Post>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
 
    public PagedList<Post> GetPosts(PostsParameters postsParameters)
    {
        return PagedList<Post>.ToPagedList(Get().OrderBy(on => on.CreatedAt),
            postsParameters.PageNumber, postsParameters.PageSize);
    }

    public async Task<IEnumerable<Post>> GetByNewestPosts()
    {
        return await Get().OrderBy(c => c.CreatedAt).ToListAsync();
    }
}
