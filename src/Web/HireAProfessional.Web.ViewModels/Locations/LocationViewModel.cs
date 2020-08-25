namespace HireAProfessional.Web.ViewModels.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;

    public class LocationViewModel : IMapFrom<City>, IMapTo<LocationViewModel>, IHaveCustomMappings
    {
        public string CountryName { get; set; }

        public string CityName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, LocationViewModel>()
                .ForMember(x => x.CityName, y => y.MapFrom(x => x.Name))
                .ForMember(x => x.CountryName, y => y.MapFrom(x => x.Country.Name));
        }
    }
}
