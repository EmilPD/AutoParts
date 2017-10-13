namespace CommonNews.Web.ViewModels.Post
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Comment;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PostViewModel : IMapBothWays<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(2500)]
        public string Content { get; set; }

        public PostCategory Category { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public string AuthorUsername { get; set; }

        public string ImageUrl { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime PostedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(postViewModel => postViewModel.AuthorUsername, cfg => cfg.MapFrom(post => post.Author.UserName))
                .ForMember(postViewModel => postViewModel.Category, cfg => cfg.MapFrom(post => post.Category))
                .ForMember(postViewModel => postViewModel.PostedOn, cfg => cfg.MapFrom(post => post.CreatedOn));

            configuration.CreateMap<PostViewModel, Post>()
                .ForMember(post => post.CreatedOn, cfg => cfg.MapFrom(postViewModel => postViewModel.PostedOn));
        }
    }
}