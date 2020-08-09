namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Companies;
    using HireAProfessional.Web.ViewModels.Applications;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Categories;
    using HireAProfessional.Web.ViewModels.Companies;
    using HireAProfessional.Web.ViewModels.Posts;

    public class CompanyService : ICompanyService
    {
        private readonly IDeletableEntityRepository<Company> repository;

        public CompanyService(IDeletableEntityRepository<Company> repository)
        {
            this.repository = repository;
        }

        public ICollection<T> GetAllCompanies<T>()
        {
            return this.repository
            .AllAsNoTracking()
            .To<T>()
            .ToList();
        }
    }
}
