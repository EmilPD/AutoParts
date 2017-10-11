namespace CommonNews.Data.Models
{
    using System.Collections.Generic;
    using Abstract;

    public class Post : BaseModel<int>
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual PostCategory Category { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
