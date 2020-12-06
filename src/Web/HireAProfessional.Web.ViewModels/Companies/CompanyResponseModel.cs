namespace HireAProfessional.Web.ViewModels.Companies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;

    public class CompanyResponseModel : IMapFrom<Company>, IMapTo<CompanyResponseModel>
    {
        public string Name { get; set; }
    }
}
