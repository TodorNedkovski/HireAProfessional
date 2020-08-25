namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Locations;
    using Microsoft.EntityFrameworkCore;

    public class LocationsService : ILocationsService
    {
        private readonly IDeletableEntityRepository<Country> countryRepository;
        private readonly IDeletableEntityRepository<City> cityRepository;

        public LocationsService(IDeletableEntityRepository<Country> countryRepository, IDeletableEntityRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
            this.countryRepository = countryRepository;
        }

        public async Task CreateAsync(LocationViewModel location)
        {
            var city = await this.cityRepository.AllAsNoTracking().FirstOrDefaultAsync(c => c.Name == location.CityName);
            var country = await this.countryRepository.AllAsNoTracking().FirstOrDefaultAsync(c => c.Name == location.CountryName);

            if (city == null)
            {
                await this.cityRepository.AddAsync(new City
                {
                    CountryId = country.Id,
                    Name = location.CityName,
                });
            }
            else
            {
                country.Cities.Add(city);
            }

            await this.cityRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string cityId, string countryId)
        {
            var city = await this.cityRepository.AllAsNoTracking().FirstOrDefaultAsync(c => c.Id == cityId);
            var country = await this.countryRepository.AllAsNoTracking().FirstOrDefaultAsync(c => c.Id == countryId);

            country.Cities.Remove(city);

            await this.countryRepository.SaveChangesAsync();
        }

        public Task EditAsync(string cityId, string countryId, LocationViewModel post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll<T>(int take, int skips)
        {
            return this.cityRepository
                .AllAsNoTracking()
                .Skip(skips)
                .Take(take)
                .To<T>();
        }
    }
}
