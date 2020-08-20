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
    using HireAProfessional.Web.ViewModels.Applications;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await this.usersRepository.All().FirstOrDefaultAsync(u => u.Id == userId);
            this.usersRepository.Delete(user);
            await this.usersRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(string userId, ApplicationUser user)
        {
            var userToUpdate = this.usersRepository.All().FirstOrDefault(u => u.Id == userId);

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Age = user.Age;
            userToUpdate.Email = user.Email;
            userToUpdate.CompanyId = user.CompanyId;
            userToUpdate.Education = user.Education;

            await this.usersRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int take, int skips)
        {
            return this.usersRepository
                .AllAsNoTracking()
                .To<T>()
                .Skip(skips)
                .Take(take)
                .ToList();
        }
    }
}
