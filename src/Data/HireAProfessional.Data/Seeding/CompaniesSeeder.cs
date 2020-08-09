namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;

    public class CompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Companies.Any())
            {
                return;
            }

            var companies = new List<Company>()
            {
                new Company
                {
                    Name = "Apple",
                },
                new Company
                {
                    Name = "Microsoft",
                },
                new Company
                {
                    Name = "Amazon",
                },
                new Company
                {
                    Name = "Samsung",
                },
            };

            await dbContext.AddRangeAsync(companies);
            await dbContext.SaveChangesAsync();
        }
    }
}
