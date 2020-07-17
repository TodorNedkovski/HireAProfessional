namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : Controller
    {
        private readonly IPostService postsService;

        public PostsController(IPostService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult BySearch()
        {
            var searchResult = this.postsService.GetAllPosts();

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
        public IActionResult CreatePost(PostInputViewModel post)
        {
            this.postsService.CreatePost(post).GetAwaiter().GetResult();

            return this.Redirect("/");
        }
    }
}
