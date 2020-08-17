namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Applications;

    public interface IUsersService
    {
        IEnumerable<T> GetAll<T>();

        Task Delete(string userId);
    }
}
