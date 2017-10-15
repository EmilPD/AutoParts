namespace CommonNews.Data.Common
{
    using System.Data.Entity;
    using Contracts;
    using Models;

    public interface IMsSqlDbContext
    {
        IDbSet<Post> Posts { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<PostCategory> PostCategories { get; set; }

        IEntryState<T> GetState<T>(T entity)
            where T : class;
    }
}
