namespace CommonNews.Web.ViewModels.Category
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;
    using Post;

    public class CategoryViewModel : IMapFrom<PostCategory>
    {
        public string Name { get; set; }

        public ICollection<PostViewModel> Posts { get; set; }
    }
}