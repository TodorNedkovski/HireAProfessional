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
        private readonly ICategoriesService categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Authorize]
        public IActionResult CategoryByName(string name)
        {
            var category = this.categoryService.GetCategoryByName(name);

            return this.View(category);
        }
    }
}
