namespace HireAProfessional.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Posts;

    public class CategoryViewModel : IMapFrom<Category>, IMapTo<CategoryViewModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ApplicationUserViewModel> ApplicationUsers { get; set; }

        public int PostsCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Category, CategoryViewModel>()
                .ForMember(x => x.PostsCount, options =>
                {
                    options.MapFrom(p => p.Posts.Count);
                });
        }
    }
}
