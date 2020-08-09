namespace HireAProfessional.Web.ViewModels.Administration.Dashboard.Applicants
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;

    public class DashboardApplicantViewModel : IMapFrom<ApplicationUser>, IMapTo<DashboardApplicantViewModel>
    {
        public string FirstName { get; set; }
    }
}
