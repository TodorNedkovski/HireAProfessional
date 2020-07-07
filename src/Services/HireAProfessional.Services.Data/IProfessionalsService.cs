namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Professionals;

    public interface IProfessionalsService
    {
        ProfessionalsListViewModel GetAllProfessionals();
    }
}
