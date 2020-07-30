namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Countries;
    using Newtonsoft.Json;

    public class CountriesService : ICountriesService
    {
        private IDeletableEntityRepository<Country> countryRepository;

        public CountriesService(IDeletableEntityRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IEnumerable<T> GetAllCountries<T>()
        {
            return this.countryRepository
                .AllAsNoTracking()
                .To<T>()
                .ToList();
        }
    }
}
