namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.Infrastructure;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Blogs;

    public class BlogsService : IBlogsService
    {
        private readonly IDeletableEntityRepository<Blog> blogRepository;

        public BlogsService(IDeletableEntityRepository<Blog> blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task CreateBlog(BlogInputViewModel blog)
        {
            await this.blogRepository.AddAsync(new Blog
            {
                Author = new ApplicationUser
                {
                    FacebookAccountLink = blog.Author.FacebookAccountLink,
                    FirstName = blog.Author.FirstName,
                    Age = blog.Author.Age,
                    LastName = blog.Author.LastName,
                    CompanyId = blog.Author.Company.Id,
                    Education = blog.Author.Education,
                    ImageUrl = blog.Author.ImageUrl,
                },
                Content = blog.Content,
                Title = blog.Title,
            });
        }

        public BlogsListViewModel GetAllBlogs(int count, string param, OrderType orderType)
        {
            return new BlogsListViewModel
            {
                Blogs = this.blogRepository
                .AllAsNoTracking()
                .Take(count)
                .OrderBy<Blog>(param, orderType)
                .Select(b => new BlogViewModel
                {
                    Author = new ApplicationUserViewModel
                    {
                        FacebookAccountLink = b.Author.FacebookAccountLink,
                        FirstName = b.Author.FirstName,
                        Age = b.Author.Age,
                        LastName = b.Author.LastName,
                        CompanyId = b.Author.Company.Id,
                        Education = b.Author.Education,
                        ImageUrl = b.Author.ImageUrl,
                    },
                    Content = b.Content,
                    Title = b.Title,
                })
                .ToList(),
            };
        }

        public BlogViewModel GetBlogById(string id)
        {
            var blog = this.blogRepository
                .All()
                .FirstOrDefault(b => b.Id == id);

            return new BlogViewModel
            {
                Author = new ApplicationUserViewModel
                {
                    FacebookAccountLink = blog.Author.FacebookAccountLink,
                    FirstName = blog.Author.FirstName,
                    Age = blog.Author.Age,
                    LastName = blog.Author.LastName,
                    CompanyId = blog.Author.Company.Id,
                    Education = blog.Author.Education,
                    ImageUrl = blog.Author.ImageUrl,
                },
                Content = blog.Content,
                Title = blog.Title,
            };
        }

        public BlogViewModel GetBlogByTitle(string title)
        {
            var blog = this.blogRepository
                .All()
                .FirstOrDefault(b => b.Title == title);

            return new BlogViewModel
            {
                Author = new ApplicationUserViewModel
                {
                    FacebookAccountLink = blog.Author.FacebookAccountLink,
                    FirstName = blog.Author.FirstName,
                    Age = blog.Author.Age,
                    LastName = blog.Author.LastName,
                    CompanyId = blog.Author.Company.Id,
                    Education = blog.Author.Education,
                    ImageUrl = blog.Author.ImageUrl,
                },
                Content = blog.Content,
                Title = blog.Title,
            };
        }
    }
}
