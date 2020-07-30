namespace HireAProfessional.Web.ViewModels.Countries
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Ctites;

    public class CountryViewModel : IMapFrom<Country>, IMapTo<Country>, IHaveCustomMappings
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public ICollection<CityViewModel> Cities { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Country, CountryViewModel>()
                .ForMember(x => x.Cities, options =>
                {
                    options.MapFrom(p => p.Cities);
                });
        }
    }
}
