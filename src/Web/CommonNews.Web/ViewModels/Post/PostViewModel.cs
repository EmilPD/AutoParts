namespace CommonNews.Web.ViewModels.Post
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public PostCategory Category { get; set; }

        public ApplicationUser Author { get; set; }

        public string AuthorUsername { get; set; }

        public string ImageUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(postViewModel => postViewModel.AuthorUsername, cfg => cfg.MapFrom(post => post.Author.UserName))
                .ForMember(postViewModel => postViewModel.PostedOn, cfg => cfg.MapFrom(post => post.CreatedOn));
        }
    }
}