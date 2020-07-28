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

    public class CountriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Countries.Any())
            {
                return;
            }

            for (int offset = 0; offset <= 190; offset += 10)
            {
                var countriesJsonModel = APIService<CountryJsonModel>.GetCountries(offset, "countries").Data;

                var countries = new List<Country>();

                foreach (var countryJsonModel in countriesJsonModel)
                {
                    countries.Add(new Country
                    {
                        Code = countryJsonModel.Code,
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
