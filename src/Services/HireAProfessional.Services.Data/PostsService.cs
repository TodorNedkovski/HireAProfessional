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
    using HireAProfessional.Services.Mapping;
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
        private readonly IDeletableEntityRepository<Company> companyRepository;

        public PostsService(
            IDeletableEntityRepository<JobPost> postRepository,
            IDeletableEntityRepository<Category> categoryRepository,
            IDeletableEntityRepository<Country> countryRepository,
            IDeletableEntityRepository<City> cityRepository,
            IDeletableEntityRepository<Company> companyRepository)
        {
            this.postRepository = postRepository;
            this.categoryRepository = categoryRepository;
            this.countryRepository = countryRepository;
            this.cityRepository = cityRepository;
            this.companyRepository = companyRepository;
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

            var company = await this.companyRepository
                .AllAsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == post.CompanyName);

            await this.postRepository.AddAsync(new JobPost
            {
                HighestSalary = 100,
                StartingSalary = 11000,
                CompanyId = company.Id,
                CategoryId = category.Id,
                JobTitle = post.JobTitle,
                CountryId = country.Id,
                CityId = city.Id,
                EmploymentType = post.EmploymentType,
                Description = post.Description,
            });

            await this.postRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string postId)
        {
            var post = await this.postRepository.All().FirstOrDefaultAsync(p => p.Id == postId);

            if (post == null)
            {
                this.postRepository.Delete(post);
                await this.postRepository.SaveChangesAsync();
            }
        }

        public PostsListViewModel GetAllPosts(int count, int skip, string param, string jobConstraints, string location, OrderType orderType)
        {
            var geolocation = GeolocationAPIService.GetCurrentLocation();

            string countryName = string.Empty;
            string cityName = string.Empty;
            string state = string.Empty;

            string jobTitle = string.Empty;

            if (string.IsNullOrEmpty(location) || location.ToLower() == "all")
            {
                countryName = geolocation.CountryName;
                cityName = geolocation.CityName;
                state = geolocation.State;
            }
            else
            {
                countryName = location.Split(", ")[1];
                cityName = location.Split(", ")[0];
            }

            if (string.IsNullOrEmpty(jobConstraints))
            {
                jobConstraints = "lol 123";
            }

            var posts = this.postRepository
            .All()
            .Where(p => p.Country.Name.ToLower() == countryName.ToLower()
            || p.City.Name.ToLower() == cityName.ToLower()
            || p.JobTitle.ToLower() == jobConstraints.ToLower())
            .OrderBy<JobPost>(param, orderType)
            .Skip(skip)
            .Take(count)
            .To<PostViewModel>()
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
                        .To<PostViewModel>()
                        .Where(p => p.Category.Name == categoryName)
                        .ToList(),
            };
        }

        public int GetCountsBySearch(string param = "Id", string jobConstraints = "all", string location = "all", OrderType orderType = OrderType.Ascending)
        {
            throw new NotImplementedException();
        }

        public PostViewModel GetPostById(string id, string userId)
        {
            var companyId = this.postRepository
                .AllAsNoTracking()
                .Include(p => p.Company)
                .FirstOrDefault(p => p.Id == id)
                .Company
                .Id;

            var post = this.postRepository
                .All()
                .To<PostViewModel>(new Dictionary<string, object> { ["userId"] = userId, ["companyId"] = companyId })
                .FirstOrDefault(p => p.Id == id);

            return post;
        }
    }
}
