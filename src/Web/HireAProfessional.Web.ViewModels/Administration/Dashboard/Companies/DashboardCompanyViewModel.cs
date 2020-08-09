namespace HireAProfessional.Web.ViewModels.Administration.Dashboard.Companies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Applications;

    public class DashboardCompanyViewModel : IMapFrom<Company>, IMapTo<DashboardCompanyViewModel>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int EmployeesCount { get; set; }

        public ICollection<DashboardApplicationViewModel> Applications { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Company, DashboardCompanyViewModel>()
                .ForMember(x => x.EmployeesCount, options =>
                {
                    options.MapFrom(c => c.Employees.Count);
                });
        }
    }
}
