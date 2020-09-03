namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Route("Administration/Dashboard/Posts/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Posts"));
        }

        [Route("Administration/Dashboard/Posts/CrudOperations")]
        public IActionResult CrudOperations(int page = 1)
        {
            var posts = this.postsService.GetAllPosts(10, (page - 1) * 10);
            var count = this.postsService.GetAllPosts().Posts.Count;

            posts.CurrentPage = page;
            posts.PagesCount = (int)Math.Ceiling((double)count / 10);

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Posts"), posts);
        }
    }
}
