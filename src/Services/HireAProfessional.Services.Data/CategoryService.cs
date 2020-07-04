namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public ICollection<Category> GetAllCategories()
        {
            return this.categoryRepository.All().ToList();
        }
    }
}
