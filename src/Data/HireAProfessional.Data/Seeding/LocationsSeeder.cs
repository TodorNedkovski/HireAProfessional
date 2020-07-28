namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services;
    using HireAProfessional.Services.Json;

    public class LocationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Locations.Any())
            {
                return;
            }

            var countries = dbContext.Countries;
            var locations = new List<Location>();

            foreach (var country in countries)
            {
                locations.Add(new Location
                {
                    Country = country,
                    Cites = country.Cities,
                });
            }

            await dbContext.AddRangeAsync(locations);
            await dbContext.SaveChangesAsync();
        }
    }
}
