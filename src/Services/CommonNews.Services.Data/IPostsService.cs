namespace CommonNews.Services.Data
{
    using System.Linq;
    using CommonNews.Data.Models;

    public interface IPostsService
    {
        IQueryable<Post> GetAll();
    }
}