namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationsService : IApplicationsService
    {
        private IDeletableEntityRepository<Application> applicationRepository;

        public ApplicationsService(IDeletableEntityRepository<Application> applicationRepository)
        {
            this.applicationRepository = applicationRepository;
        }

        public async Task Approve(string id)
        {
            var aplication = await this.applicationRepository.AllAsNoTracking().FirstOrDefaultAsync(a => a.Id == id);

            this.applicationRepository.Delete(aplication);

            await this.applicationRepository.SaveChangesAsync();
        }

        public async Task CreateApplicationAsync(string userId, string companyId)
        {
            await this.applicationRepository.AddAsync(new Application
            {
                ApplicationUserId = userId,
                CompanyId = companyId,
            });

            await this.applicationRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int take, int skips)
        {
            return this.applicationRepository
                .AllAsNoTracking()
                .Skip(skips)
                .Take(take)
                .To<T>();
        }
    }
}
