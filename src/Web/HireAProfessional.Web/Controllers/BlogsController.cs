namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HireAProfessional.Services.Data;
    using Microsoft.AspNetCore.Mvc;

    public class BlogsController : Controller
    {
        private IBlogsService blogService;

        public BlogsController(IBlogsService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult ByBlogTitle(string title)
        {
            var blog = this.blogService.GetBlogByTitle(title);

            return this.View(blog);
        }

        public IActionResult AllBlogs()
        {
            var result = this.blogService.GetAllBlogs();

            return this.View(result);
        }
    }
}
