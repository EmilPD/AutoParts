namespace CommonNews.Web.ViewModels.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapBothWays<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }

        public string AuthorUsername { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime CommentedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(commentViewModel => commentViewModel.PostId, cfg => cfg.MapFrom(comment => comment.Post.Id))
                .ForMember(commentViewModel => commentViewModel.AuthorUsername, cfg => cfg.MapFrom(comment => comment.Author.UserName))
                .ForMember(commentViewModel => commentViewModel.CommentedOn, cfg => cfg.MapFrom(comment => comment.CreatedOn));
        }
    }
}