namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class JobPostsController : Controller
    {
        private readonly IPostsService postsService;

        public JobPostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult BySearch(string location, string jobConstraints)
        {
            var searchResult = this.postsService.GetAllPosts(10, "Id", jobConstraints, location, OrderType.Ascending);
            var searchResult1 = this.postsService.GetAllPosts(10);

            return this.View(searchResult);
        }

        [Authorize]
        public IActionResult ById(string id)
        {
            var post = this.postsService.GetPostById(id);

            return this.View(post);
        }

        [Authorize]
        public IActionResult CreatePost()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostInputViewModel post)
        {
            await this.postsService.CreatePost(post);

            return this.Redirect("/");
        }
    }
}
