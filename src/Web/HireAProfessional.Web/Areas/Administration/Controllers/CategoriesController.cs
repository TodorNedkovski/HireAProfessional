namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [Route("Administration/Dashboard/Categories/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Categories"));
        }

        [Route("Administration/Dashboard/Categories/CrudOperations")]
        public IActionResult CrudOperations()
        {
            var categories = this.categoriesService.GetAll<CategoryViewModel>();

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Categories"), categories);
        }

        [Route("Administration/Dashboard/Categories/CrudOperations/Create")]
        public async Task<IActionResult> Create(string categoryName, string description)
        {
            await this.categoriesService.Create(new Category
            {
                Name = categoryName,
                Description = description,
                ImageUrl = string.Empty,
            });

            return this.RedirectToAction("CrudOperations");
        }
    }
}
