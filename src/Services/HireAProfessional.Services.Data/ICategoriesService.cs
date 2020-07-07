namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.Categories;

    public interface ICategoriesService
    {
        CategoriesListViewModel GetAllCategories();

        CategoryViewModel GetCategoryByName(string name);
    }
}
