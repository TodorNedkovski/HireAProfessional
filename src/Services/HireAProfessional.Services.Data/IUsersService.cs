namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.Applications;

    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();

        Task DeleteAsync(string userId);

        Task UpdateAsync(string userId, ApplicationUser user);
    }
}
