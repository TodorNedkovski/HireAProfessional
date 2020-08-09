namespace HireAProfessional.Web.ViewModels.Companies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;

    public class CompaniesListViewModel
    {
        public ICollection<CompanyViewModel> Companies { get; set; }
    }
}
