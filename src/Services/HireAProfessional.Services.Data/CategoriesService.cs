namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.Categories;
    using HireAProfessional.Web.ViewModels.Professionals;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoriesListViewModel GetAllCategories()
        {
            return new CategoriesListViewModel
            {
                Categories = this.categoryRepository.All().Select(c => new CategoryViewModel
                {
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                    Professionals = c.Professionals.Select(p => new ProfessionalViewModel 
                    {
                        FirstName = 1,
                    }),
                }).ToList(),
            };
        }

        public CategoryViewModel GetCategoryByName(string name)
        {
            var category = this.categoryRepository
                .All()
                .FirstOrDefault(c => c.Name == name.Replace("-", " "));

            return new CategoryViewModel
            {
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
                Professionals = category.Professionals.Select(p => new ProfessionalViewModel 
                {
                    Company = "g",
                }),
            };
        }
    }
}
