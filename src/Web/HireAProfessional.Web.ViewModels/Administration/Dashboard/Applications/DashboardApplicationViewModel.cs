namespace HireAProfessional.Web.ViewModels.Administration.Dashboard.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Applicants;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Companies;

    public class DashboardApplicationViewModel : IMapFrom<Application>, IMapTo<DashboardApplicationViewModel>
    {
        public string Id { get; set; }

        public string CompanyId { get; set; }

        public DashboardCompanyViewModel Company { get; set; }

        public string ApplicantId { get; set; }

        public DashboardApplicantViewModel Applicant { get; set; }
    }
}
