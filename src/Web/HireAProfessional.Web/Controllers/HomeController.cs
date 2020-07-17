﻿namespace HireAProfessional.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels;
    using HireAProfessional.Web.ViewModels.Categories;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IPostService postsService;

        public HomeController(IPostService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
