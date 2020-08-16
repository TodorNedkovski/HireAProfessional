namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class JobPostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly UserManager<ApplicationUser> userManager;

        public JobPostsController(IPostsService postsService, UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.userManager = userManager;
        }

        public IActionResult BySearch(string location, string jobConstraints, int page = 1)
        {
            int itemsPerPage = 10;

            var searchResult = this.postsService.GetAllPosts(int.MaxValue, (page - 1) * itemsPerPage, "Id", jobConstraints, location, OrderType.Ascending);
            var count = searchResult.Posts.Count;

            searchResult.PagesCount = (int)Math.Ceiling((double)count / itemsPerPage);
            searchResult.CurrentPage = page;

            return this.View(searchResult);
        }

        [Authorize]
        public IActionResult ById(string id)
        {
            var userId = this.userManager.GetUserId(this.User);

            var post = this.postsService.GetPostById(id, userId);

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
