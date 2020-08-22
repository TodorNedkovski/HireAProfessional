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
        IEnumerable<T> GetAll<T>(int count = int.MaxValue, string param = "Id", OrderType orderType = OrderType.Ascending);

        Task Create(Category category);

        Task Delete(string categoryId);

        Task Edit(string categoryId, Category category);

        CategoryViewModel GetCategoryByName(string name);
    }
}
