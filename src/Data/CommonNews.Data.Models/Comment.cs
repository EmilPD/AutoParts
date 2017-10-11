namespace CommonNews.Data.Models
{
    using Abstract;

    public class Comment : BaseModel<int>
    {
        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Post Post { get; set; }
    }
}
