﻿namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Models.Enums;

    public class PostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.JobPosts.Any())
            {
                return;
            }

            var posts = new List<JobPosts>
            {
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Front End Developer"),
                    Company = "Microsoft",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Amazon",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
                new JobPosts
                {
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    Company = "Apple",
                    Description = "Loerm 1234",
                    JobLocation = "Santa Monica, California",
                    JobTitle = "Coffee Guy",
                    EmploymentType = EmploymentType.FullTime,
                },
            };

            await dbContext.JobPosts.AddRangeAsync(posts);
        }
    }
}