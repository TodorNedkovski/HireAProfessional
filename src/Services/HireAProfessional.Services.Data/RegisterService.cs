namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;

    public class RegisterService : IRegisterService
    {
        private readonly IDeletableEntityRepository<ProfessionalUser> professionalUserRepository;

        public RegisterService(IDeletableEntityRepository<ProfessionalUser> professionalUserRepository)
        {
            this.professionalUserRepository = professionalUserRepository;
        }

        public async Task MakeUserProfessional(ApplicationUser user, Category category)
        {
            await this.professionalUserRepository.AddAsync(new ProfessionalUser
            {
                User = user,
                Category = category,
            });
        }
    }
}
