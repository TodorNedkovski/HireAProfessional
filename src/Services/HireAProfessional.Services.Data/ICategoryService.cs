namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;

    public interface ICategoryService
    {
        ICollection<Category> GetAllCategories();
    }
}
