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
    using Microsoft.EntityFrameworkCore;
    using RestSharp;

    public class CitiesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Cities.Any())
            {
                return;
            }

            //273570

            for (int offset = 0; offset <= 100; offset += 10)
            {
                var citiesJsonModel = GeoDbAPIService<CityJsonModel>.GetCountries(offset, "cities").Data;

                var cities = new List<City>();

                foreach (var cityJsonModel in citiesJsonModel)
                {
                    cities.Add(new City
                    {
                        Country = await dbContext.Countries.FirstOrDefaultAsync(c => c.Name == cityJsonModel.Country),
                        Name = cityJsonModel.Name,
                    });
                }

                Thread.Sleep(2000);

                await dbContext.Cities.AddRangeAsync(cities);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
