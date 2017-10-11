namespace CommonNews.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class HomeViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}