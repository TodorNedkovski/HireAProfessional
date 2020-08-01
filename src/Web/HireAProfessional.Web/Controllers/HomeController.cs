namespace HireAProfessional.Web.Controllers
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels;
    using HireAProfessional.Web.ViewModels.Blogs;
    using HireAProfessional.Web.ViewModels.Categories;
    using HireAProfessional.Web.ViewModels.Indexes;
    using HireAProfessional.Web.ViewModels.Locations;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IPostsService postsService;
        private readonly IBlogsService blogsService;
        private readonly ICategoriesService categoriesService;

        public HomeController(IPostsService postsService, IBlogsService blogsService, ICategoriesService categoriesService)
        {
            this.postsService = postsService;
            this.blogsService = blogsService;
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var location = GeolocationAPIService.GetCurrentLocation();

            var indexModel = new IndexViewModel
            {
                BlogsListViewModel = this.blogsService.GetAllBlogs(3, "CreatedOn", OrderType.Descending),
                CategoriesListViewModel = this.categoriesService.GetAllCategories(8, "CreatedOn", OrderType.Descending),
                PostsListViewModel = this.postsService.GetAllPosts(5, "CreatedOn", string.Empty, string.Empty, OrderType.Descending),
                Location = new LocationViewModel
                {
                    CityName = location.CityName,
                    CountryName = location.CountryName,
                },
            };

            return this.View(indexModel);
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
