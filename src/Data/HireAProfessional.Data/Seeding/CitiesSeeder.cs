namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services;
    using HireAProfessional.Services.Json;
    using RestSharp;

    public class CitiesSeeder : ISeeder
    {
        //private readonly IMapper mapper;

        //public CitiesSeeder(IMapper mapper)
        //{
        //    this.mapper = mapper;
        //}

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            //273570

            for (int offset = 0; offset <= 100000; offset += 10)
            {
                var citiesJsonModel = APIService<CityJsonModel>.GetCountries(offset, "cities").Data;

                var cities = new List<City>();

                foreach (var cityJsonModel in citiesJsonModel)
                {
                    cities.Add(new City
                    {
                        Country = dbContext
                        .Countries
                        .FirstOrDefault(c => c.Name == cityJsonModel.Country),
                        CountryCode = cityJsonModel.CountryCode,
                        Name = cityJsonModel.Name,
                        Region = cityJsonModel.Region,
                    });
                }

                Thread.Sleep(2000);

                await dbContext.Cities.AddRangeAsync(cities);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
