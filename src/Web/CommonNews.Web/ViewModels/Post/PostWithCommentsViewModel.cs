namespace CommonNews.Web.ViewModels.Post
{
    using System.Collections.Generic;
    using Comment;

    public class PostWithCommentsViewModel
    {
        public ICollection<CommentViewModel> Comments { get; set; }

        public PostViewModel Post { get; set; }
    }
}