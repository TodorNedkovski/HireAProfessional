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
    using Microsoft.EntityFrameworkCore;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<JobPost> postRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Location> locationRepository;

        public PostsService(
            IDeletableEntityRepository<JobPost> postRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Location> locationRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.locationRepository = locationRepository;
        }

        public async Task CreatePost(PostInputViewModel post)
        {
            var category = await this.categoryRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == post.CategoryName);

            var location = await this.locationRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(l => l.Country.Name == post.Location || l.Cites.Any(c => c.Name == post.Location));

            await this.postRepository.AddAsync(new JobPost
            {
                HighestSalary = 100,
                StartingSalary = 11000,
                Company = post.CompanyName,
                CategoryId = category.Id,
                JobTitle = post.JobTitle,
                LocationId = location.Id,
                EmploymentType = post.EmploymentType,
                Description = post.Description,
            });

            await this.postRepository.SaveChangesAsync();
        }

        public PostsListViewModel GetAllPosts(int count, string param, string jobConstraints, string location, OrderType orderType)
        {
            var posts = this.
            postRepository
            .All()
            .Take(count)
            .Where(p => p.Location.Country.Name.ToLower() == location || p.Location.Country.Cities.Any(c => c.Name.ToLower() == location))
            .OrderBy<JobPost>(param, orderType)
            .Select(p => new PostViewModel
            {
                Id = p.Id,
                Company = p.Company,
                Description = p.Description,
                EmploymentType = p.EmploymentType,
                VotesCount = p.Votes.Sum(v => (int)v.JobPost.EmploymentType),
                JobLocation = p.Location,
                JobTitle = p.JobTitle,
                Category = p.Category,
            })
            .ToList();

            if (location == string.Empty || location == null)
            {
                posts = this.
                        postRepository
                        .All()
                        .Take(count)
                        .OrderBy<JobPost>(param, orderType)
                        .Select(p => new PostViewModel
                        {
                            Id = p.Id,
                            Company = p.Company,
                            Description = p.Description,
                            EmploymentType = p.EmploymentType,
                            VotesCount = p.Votes.Sum(v => (int)v.JobPost.EmploymentType),
                            JobLocation = p.Location,
                            JobTitle = p.JobTitle,
                            Category = p.Category,
                        })
                        .ToList();
            }

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
                            VotesCount = p.Votes.Sum(v => (int)v.JobPost.EmploymentType),
                            JobLocation = p.Location,
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
                .Include(p => p.Votes)
                .FirstOrDefault(p => p.Id == id);

            return new PostViewModel
            {
                Id = post.Id,
                Category = post.Category,
                Company = post.Company,
                VotesCount = post.Votes.Sum(v => (int)v.VoteType),
                Description = post.Description,
                EmploymentType = post.EmploymentType,
                JobLocation = post.Location,
                JobTitle = post.JobTitle,
            };
        }
    }
}
