namespace HireAProfessional.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Models.Enums;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Categories;

    public class PostViewModel : IMapFrom<JobPost>, IMapTo<PostViewModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string JobTitle { get; set; }

        public int VotesCount { get; set; }

        public string Company { get; set; }

        public string CompanyId { get; set; }

        public string Description { get; set; }

        public CategoryViewModel Category { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            string userId = null;
            string companyId = null;

            configuration.CreateMap<JobPost, PostViewModel>()
                .ForMember(x => x.VotesCount, options =>
                {
                    options.MapFrom(p => p.Votes.Sum(v => (int)v.VoteType));
                })
                .ForMember(x => x.UserId, options =>
                {
                    options.MapFrom(x => userId);
                })
                .ForMember(x => x.CompanyId, options =>
                {
                    options.MapFrom(x => companyId);
                });
        }
    }
}
