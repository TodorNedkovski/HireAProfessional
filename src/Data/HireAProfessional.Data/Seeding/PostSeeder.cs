namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class PostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobPosts.Any())
            {
                return;
            }

            var country = await dbContext.Countries.FirstOrDefaultAsync();
            var city = await dbContext.Cities.FirstOrDefaultAsync();

            var posts = new List<JobPost>
            {
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobTitle = "Coffee Guy",
                    City = city,
                    Country = country,
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Front End Developer"),
                    Company = "Microsoft",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Amazon",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPost
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    City = city,
                    Country = country,
                    JobTitle = "Coffee Guy",
                    HighestSalary = 10000,
                    StartingSalary = 100,
                    EmploymentType = EmploymentType.FullTime,
                },
            };

            await dbContext.JobPosts.AddRangeAsync(posts);
        }
    }
}
