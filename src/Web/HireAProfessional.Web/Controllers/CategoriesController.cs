namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Data;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly IPostsService postService;

        public CategoriesController(IPostsService postService)
        {
            this.postService = postService;
        }

        [Authorize]
        public IActionResult CategoryByName(string name)
        {
            var posts = this.postService.GetAllPostsByCategory(name);

            return this.View(posts);
        }
    }
}
