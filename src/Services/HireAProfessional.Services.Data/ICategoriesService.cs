namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Categories;

    public interface ICategoriesService
    {
        CategoriesListViewModel GetAllCategories(int count = int.MaxValue, string param = "Id", OrderType orderType = OrderType.Ascending);

        ICollection<Category> GetAllCategoriesWithoutViewModel();

        CategoryViewModel GetCategoryByName(string name);
    }
}
