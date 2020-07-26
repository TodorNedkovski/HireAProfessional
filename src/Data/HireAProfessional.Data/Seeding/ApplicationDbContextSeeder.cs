namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var assembly = Assembly.GetExecutingAssembly();
            var seederImplementors = assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(ISeeder));

            var seeders = new List<ISeeder>
                          {
                              new LocationsSeeder(),
                              new CompaniesSeeder(),
                              new CategoriesSeeder(),
                              new CitiesSeeder(),
                              new CountriesSeeder(),
                              new ApplicationUsersSeeder(),
                              new RolesSeeder(),
                              new PostSeeder(),
                              new BlogsSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}
