namespace CommonNews.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using Post;

    public class HomeViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}