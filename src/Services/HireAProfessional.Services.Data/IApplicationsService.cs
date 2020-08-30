namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels.Applications;

    public interface IApplicationsService
    {
        IEnumerable<T> GetAll<T>(int take, int skips);

        Task CreateApplicationAsync(string userId, string companyId);

        Task Approve(string id);
    }
}
