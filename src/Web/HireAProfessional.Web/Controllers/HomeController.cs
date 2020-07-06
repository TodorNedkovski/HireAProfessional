namespace HireAProfessional.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels;
    using HireAProfessional.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ICategoryService categoryService;

        public HomeController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = this.categoryService.GetAllCategories();

            return this.View(categories);
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
