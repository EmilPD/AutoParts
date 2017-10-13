namespace CommonNews.Web.ViewModels.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        //public CommentViewModel()
        //{
        //}

        //public CommentViewModel(int postId)
        //{
        //    this.PostId = postId;
        //}

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
                .ForMember(m => m.PostId, opt => opt.MapFrom(u => u.Author.Id));
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.CommentedOn, opt => opt.MapFrom(u => u.CreatedOn));
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.AuthorUsername, opt => opt.MapFrom(u => u.Author.UserName));
        }
    }
}