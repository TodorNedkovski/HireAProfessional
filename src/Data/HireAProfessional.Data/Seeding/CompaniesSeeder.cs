namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore.Diagnostics;

    public class CompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var location = dbContext.Locations.FirstOrDefault();

            var companies = new List<Company>()
            {
                new Company
                {
                    Name = "Apple",
                    Location = location,
                },
                new Company
                {
                    Name = "Microsoft",
                    Location = location,
                },
                new Company
                {
                    Name = "Amazon",
                    Location = location,
                },
                new Company
                {
                    Name = "Samsung",
                    Location = location,
                },
            };

            await dbContext.AddRangeAsync(companies);
        }
    }
}
