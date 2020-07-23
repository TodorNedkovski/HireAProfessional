namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.Infrastructure;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Posts;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<JobPost> postRepository;

        public PostsService(IDeletableEntityRepository<JobPost> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task CreatePost(PostInputViewModel post)
        {
            await this.postRepository.AddAsync(new JobPost
            {
                Company = post.Company,
                JobTitle = post.JobTitle,
                JobLocation = post.JobLocation,
                EmploymentType = post.EmploymentType,
                Description = post.Description,
            });

            await this.postRepository.SaveChangesAsync();
        }

        public PostsListViewModel GetAllPosts(int count, string param, string location, string jobConstraints, OrderType orderType)
        {
            var posts = this.
                        postRepository
                        .AllAsNoTracking()
                        .Take(count)
                        .OrderBy<JobPost>(param, orderType)
                        .Select(p => new PostViewModel
                        {
                            Id = p.Id,
                            Company = p.Company,
                            Description = p.Description,
                            EmploymentType = p.EmploymentType,
                            JobLocation = p.JobLocation,
                            JobTitle = p.JobTitle,
                            Category = p.Category,
                        })
                        .ToList();

            return new PostsListViewModel
            {
                Posts = posts,
            };
        }

        public PostsListViewModel GetAllPostsByCategory(string categoryName)
        {
            return new PostsListViewModel
            {
                Posts = this.
                        postRepository
                        .AllAsNoTracking()
                        .Select(p => new PostViewModel
                        {
                            Id = p.Id,
                            Company = p.Company,
                            Description = p.Description,
                            EmploymentType = p.EmploymentType,
                            JobLocation = p.JobLocation,
                            JobTitle = p.JobTitle,
                            Category = p.Category,
                        })
                        .Where(p => p.Category.Name == categoryName)
                        .ToList(),
            };
        }

        public PostViewModel GetPostById(string id)
        {
            var post = this.postRepository
                .All()
                .FirstOrDefault(p => p.Id == id);

            return new PostViewModel
            {
                Id = post.Id,
                Category = post.Category,
                Company = post.Company,
                Description = post.Description,
                EmploymentType = post.EmploymentType,
                JobLocation = post.JobLocation,
                JobTitle = post.JobTitle,
            };
        }
    }
}
