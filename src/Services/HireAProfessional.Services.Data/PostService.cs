namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.Posts;

    public class PostService : IPostService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task CreatePost(PostInputViewModel post)
        {
            await this.postRepository.AddAsync(new Post
            {
                Company = post.Company,
                JobTitle = post.JobTitle,
                JobLocation = post.JobLocation,
                EmploymentType = post.EmploymentType,
                Description = post.Description,
            });
        }

        public PostAllViewModel GetAllPosts()
        {
            return new PostAllViewModel
            {
                Posts = this.
                        postRepository
                        .AllAsNoTracking()
                        .Select(p => new PostViewModel
                        {
                            Company = p.Company,
                            Description = p.Description,
                            EmploymentType = p.EmploymentType,
                            JobLocation = p.JobLocation,
                            JobTitle = p.JobTitle,
                            Category = p.Category,
                        })
                        .ToList(),
            };
        }

        public PostAllViewModel GetAllPostsByCategory(string categoryName)
        {
            return new PostAllViewModel
            {
                Posts = this.
                        postRepository
                        .AllAsNoTracking()
                        .Select(p => new PostViewModel
                        {
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
    }
}
