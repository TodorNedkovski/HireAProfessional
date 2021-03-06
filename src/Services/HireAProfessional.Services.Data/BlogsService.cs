﻿namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.Infrastructure;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Blogs;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ValueGeneration;

    public class BlogsService : IBlogsService
    {
        private readonly IDeletableEntityRepository<Blog> blogRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public BlogsService(IDeletableEntityRepository<Blog> blogRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.blogRepository = blogRepository;
            this.userRepository = userRepository;
        }

        public async Task CreateAsync(BlogInputViewModel blog)
        {
            var author = this.userRepository.AllAsNoTracking().FirstOrDefault(u => u.Id == blog.AuthorId);

            await this.blogRepository.AddAsync(new Blog
            {
                AuthorId = author.Id,
                Content = blog.Content,
                Title = blog.Title,
            });

            await this.blogRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string blogId)
        {
            var blog = await this.blogRepository
                .All()
                .FirstOrDefaultAsync(b => b.Id == blogId);

            blog.IsDeleted = true;

            await this.blogRepository.SaveChangesAsync();
        }

        public async Task EditAsync(string blogId, BlogInputViewModel blog)
        {
            var blogToEdit = await this.blogRepository
                .All()
                .FirstOrDefaultAsync(b => b.Id == blogId);

            blogToEdit.Title = blog.Title;
            blogToEdit.Content = blog.Content;

            await this.blogRepository.SaveChangesAsync();
        }

        public BlogsListViewModel GetAll(int count, int skip, string param, OrderType orderType)
        {
            return new BlogsListViewModel
            {
                Blogs = this.blogRepository
                .AllAsNoTracking()
                .Skip(skip)
                .Take(count)
                .OrderBy<Blog>(param, orderType)
                .Select(b => new BlogViewModel
                {
                    Id = b.Id,
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

            var blogAuthor = this.userRepository.All().FirstOrDefault(u => u.Id == blog.AuthorId);

            var valToReturn = new BlogViewModel
            {
                Author = new ApplicationUserViewModel 
                {
                    FirstName = blogAuthor.FirstName,
                    LastName = blogAuthor.LastName,
                    Age = blogAuthor.Age,
                },
                Content = blog.Content,
                Title = blog.Title,
            };

            return valToReturn;
        }
    }
}
