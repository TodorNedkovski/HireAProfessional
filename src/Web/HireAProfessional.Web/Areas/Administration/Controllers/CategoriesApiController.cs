namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesApiController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [Route("api/categories/create")]
        public async Task<ActionResult<CategoryResponseModel>> Create(CategoryRequestModel request)
        {
            await this.categoriesService.Create(new Category
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = string.Empty,
            });

            return new CategoryResponseModel { };
        }

        [Route("api/categories/delete")]
        public async Task<ActionResult<CategoryResponseModel>> Delete(CategoryRequestModel request)
        {
            await this.categoriesService.Delete(request.CategoryId);

            return new CategoryResponseModel { };
        }

        [Route("api/categories/edit")]
        public async Task<ActionResult<CategoryResponseModel>> Edit(CategoryRequestModel request)
        {
            await this.categoriesService.Edit(request.CategoryId, new Category
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = string.Empty,
            });

            return new CategoryResponseModel { };
        }
    }
}
