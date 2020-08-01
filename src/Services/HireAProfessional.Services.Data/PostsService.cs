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
    using HireAProfessional.Services;
    using HireAProfessional.Web.Infrastructure;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.EntityFrameworkCore;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<JobPost> postRepository;
        private readonly IDeletableEntityRepository<Category> categoryRepository;
        private readonly IDeletableEntityRepository<Country> countryRepository;
        private readonly IDeletableEntityRepository<City> cityRepository;

        public PostsService(
            IDeletableEntityRepository<JobPost> postRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Country> countryRepository,
            IDeletableEntityRepository<City> cityRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
        }

        public async Task CreatePost(PostInputViewModel post)
        {
            string cityName = post.Location.Split(", ")[0];
            string countryName = post.Location.Split(", ")[1];

            var category = await this.categoryRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == post.CategoryName);

            var country = await this.countryRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == countryName);

            var city = await this.cityRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == cityName);

            await this.postRepository.AddAsync(new JobPost
            {
                HighestSalary = 100,
                StartingSalary = 11000,
                Company = post.CompanyName,
                CategoryId = category.Id,
                JobTitle = post.JobTitle,
                CountryId = country.Id,
                CityId = city.Id,
                EmploymentType = post.EmploymentType,
                Description = post.Description,
            });

            await this.postRepository.SaveChangesAsync();
        }

        public PostsListViewModel GetAllPosts(int count, string param, string jobConstraints, string location, OrderType orderType)
        {
            string countryName = string.Empty;
            string cityName = string.Empty;

            if (string.IsNullOrEmpty(location))
            {
                countryName = GeolocationAPIService.GetCurrentLocation().CountryName;
                cityName = GeolocationAPIService.GetCurrentLocation().CityName;
            }
            else
            {
                countryName = location.Split(", ")[1];
                cityName = location.Split(", ")[0];
            }

            jobConstraints = string.Empty;

            var posts = this.postRepository
            .All()
            .Where(p => p.Country.Name.ToLower() == countryName.ToLower()
            || p.City.Name.ToLower() == cityName.ToLower()
            || p.Category.Name == jobConstraints.ToLower()
            || p.JobTitle == jobConstraints.ToLower())
            .OrderBy<JobPost>(param, orderType)
            .Take(count)
            .Select(p => new PostViewModel
            {
                Id = p.Id,
                Company = p.Company,
                Description = p.Description,
                EmploymentType = p.EmploymentType,
                VotesCount = p.Votes.Sum(v => (int)v.JobPost.EmploymentType),
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
                            VotesCount = p.Votes.Sum(v => (int)v.JobPost.EmploymentType),
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
                JobTitle = post.JobTitle,
            };
        }
    }
}
