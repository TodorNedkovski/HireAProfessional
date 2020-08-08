namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;

    public class ApplicationService : IApplicationService
    {
        private IDeletableEntityRepository<Application> applicationRepository;

        public ApplicationService(IDeletableEntityRepository<Application> applicationRepository)
        {
            this.applicationRepository = applicationRepository;
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
    }
}
