namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.Infrastructure.Enums;
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

        public IActionResult AllBlogs(int page = 1)
        {
            int itemsPerPage = 10;

            var searchResult = this.blogService.GetAll(itemsPerPage, (page - 1) * itemsPerPage, "Id", OrderType.Ascending);
            var count = this.blogService.GetAll(int.MaxValue, 0, "Id", OrderType.Ascending).Blogs.Count;

            searchResult.PagesCount = (int)Math.Ceiling((double)count / itemsPerPage);
            searchResult.CurrentPage = page;

            return this.View(searchResult);
        }
    }
}
