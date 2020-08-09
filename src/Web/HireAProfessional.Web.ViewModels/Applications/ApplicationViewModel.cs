namespace HireAProfessional.Web.ViewModels.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Companies;

    public class ApplicationViewModel : IMapFrom<Application>, IMapTo<ApplicationViewModel>
    {
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUserViewModel ApplicationUser { get; set; }

        public string CompanyId { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}
