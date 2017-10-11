namespace CommonNews.Services.Data
{
    using System.Linq;
    using CommonNews.Data.Common.Contracts;
    using CommonNews.Data.Models;

    public class PostsService : BaseDataService<Post>, IPostsService
    {
        public PostsService(IEfRepository<Post> repo, ISaveContext context)
            : base(repo, context)
        {
        }

        public void Update(Post post)
        {
            this.Data.Update(post);
            this.Context.Commit();
        }
    }
}
