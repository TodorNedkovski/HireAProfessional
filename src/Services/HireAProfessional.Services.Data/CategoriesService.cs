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
                }).ToList(),
            };
        }

        public ICollection<Category> GetAllCategoriesWithoutViewModel()
        {
            return this.categoryRepository.All().ToList();
        }

        public CategoryViewModel GetCategoryByName(string name)
        {
            return this.categoryRepository
                .All()
                .Select(c => new CategoryViewModel
                {
                    Name = c.Name,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Professionals = c.ProfessionalUsers.Select(p => new ProfessionalViewModel
                    {
                        FirstName = p.User.FirstName,
                        LastName = p.User.LastName,
                        FacebookAccountLink = p.User.FacebookAccountLink,
                        TwitterAccountLink = p.User.TwitterAccountLink,
                        LinkedInAccountLink = p.User.LinkedInAccountLink,
                        Age = p.User.Age,
                        Company = p.User.Company,
                        Education = p.User.Education,
                        ImageUrl = p.User.ImageUrl,
                    }),
                })
                .FirstOrDefault(c => c.Name == name.Replace("-", " "));
        }
    }
}
