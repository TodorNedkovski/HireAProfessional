namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;

    public interface IRegisterService
    {
        Task MakeUserProfessional(ApplicationUser user, Category category);
    }
}
