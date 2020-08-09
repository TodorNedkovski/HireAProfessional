namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.Infrastructure;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Categories;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public CategoriesListViewModel GetAllCategories(int count, string param, OrderType orderType)
        {
            var categories = this.categoryRepository
                .All()
                .Take(count)
                .OrderBy<Category>(param, orderType)
                .Select(c => new CategoryViewModel
                {
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Name = c.Name,
                })
                .ToList();

            return new CategoriesListViewModel
            {
                Categories = categories,
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
                    ApplicationUsers = c.ApplicationUserCategories.Select(p => new ApplicationUserViewModel
                    {
                        FirstName = p.ApplicationUser.FirstName,
                        LastName = p.ApplicationUser.LastName,
                        FacebookAccountLink = p.ApplicationUser.FacebookAccountLink,
                        TwitterAccountLink = p.ApplicationUser.TwitterAccountLink,
                        LinkedInAccountLink = p.ApplicationUser.LinkedInAccountLink,
                        Age = p.ApplicationUser.Age,
                        CompanyId = p.ApplicationUser.Company.Id,
                        Education = p.ApplicationUser.Education,
                        ImageUrl = p.ApplicationUser.ImageUrl,
                    }),
                })
                .FirstOrDefault(c => c.Name == name.Replace("-", " "));
        }
    }
}
