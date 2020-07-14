namespace HireAProfessional.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Web.ViewModels.ApplicationUsers;

    public class CategoryViewModel
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<ApplicationUserViewModel> ApplicationUsers { get; set; }
    }
}
