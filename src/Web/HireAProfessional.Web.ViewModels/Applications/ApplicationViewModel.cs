namespace HireAProfessional.Web.ViewModels.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Companies;

    public class ApplicationViewModel : IMapFrom<Application>, IMapTo<ApplicationViewModel>
    {
        public string Id { get; set; }

        public string ApplicationUserId { get; set; }

        public string ApplicationUserFirstName { get; set; }

        public string ApplicationUserLastName { get; set; }

        public string CompanyId { get; set; }

        public string CompanyName { get; set; }
    }
}
