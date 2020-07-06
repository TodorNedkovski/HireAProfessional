namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.Categories;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public ICollection<CategoryViewModel> GetAllCategories()
        {
            return this.categoryRepository.All().Select(c => new CategoryViewModel
            {
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Name = c.Name,
            }).ToList();
        }
    }
}
