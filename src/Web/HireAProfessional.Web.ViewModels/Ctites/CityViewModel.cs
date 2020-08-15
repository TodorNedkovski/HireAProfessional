namespace HireAProfessional.Web.ViewModels.Ctites
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;

    public class CityViewModel : IMapFrom<City>, IMapTo<CityViewModel>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string CountryName { get; set; }

        public string CountryCode { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
        }
    }
}
