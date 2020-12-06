namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services;
    using HireAProfessional.Services.Json;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.Extensions.Configuration;

    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Duplicate here any configuration sources you use.
            configurationBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            for (int offset = 0; offset <= 190; offset += 10)
            {
                var countriesJsonModel = new GeoDbAPIService<CityJsonModel>(configuration).Get(offset, "countries").Data;

                var countries = new List<Country>();

                foreach (var countryJsonModel in countriesJsonModel)
                {
                    countries.Add(new Country
                    {
                        Name = countryJsonModel.Name,
                    });
                }

                Thread.Sleep(2000);

                await dbContext.Countries.AddRangeAsync(countries);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
