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
    using Microsoft.EntityFrameworkCore;

    public class CompaniesService : ICompaniesService
    {
        private readonly IDeletableEntityRepository<Company> repository;

        public CompaniesService(IDeletableEntityRepository<Company> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync(string name)
        {
            await this.repository.AddAsync(new Company
            {
                Name = name,
            });

            await this.repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var company = await this.repository.All().FirstOrDefaultAsync(c => c.Id == id);

            this.repository.Delete(company);

            await this.repository.SaveChangesAsync();
        }

        public ICollection<T> GetAll<T>(int take, int skips)
        {
            return this.repository
            .All()
            .To<T>()
            .Take(take)
            .ToList();
        }
    }
}
