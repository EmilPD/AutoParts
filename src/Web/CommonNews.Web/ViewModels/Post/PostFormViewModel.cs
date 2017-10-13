namespace CommonNews.Web.ViewModels.Post
{
    using System.Collections.Generic;
    using Data.Models;

    public class PostFormViewModel
    {
        public IEnumerable<PostCategory> Categories { get; set; }

        public PostViewModel Post { get; set; }
    }
}