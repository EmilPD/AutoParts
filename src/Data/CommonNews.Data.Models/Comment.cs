namespace CommonNews.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Abstract;

    public class Comment : BaseModel<int>
    {
        [Required]
        [StringLength(1024)]
        public string Content { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual Post Post { get; set; }
    }
}
