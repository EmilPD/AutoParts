namespace CommonNews.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Abstract;

    public class Post : BaseModel<int>
    {
        private ICollection<Comment> comments;

        public Post()
        {
            this.comments = new HashSet<Comment>();
        }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(2500)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public ApplicationUser Author { get; set; }

        public PostCategory Category { get; set; }

        public ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
