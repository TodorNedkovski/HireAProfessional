namespace HireAProfessional.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;

    public class CategoryViewModel : IMapFrom<Category>, IMapTo<CategoryViewModel>
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ApplicationUserViewModel> ApplicationUsers { get; set; }
    }
}
