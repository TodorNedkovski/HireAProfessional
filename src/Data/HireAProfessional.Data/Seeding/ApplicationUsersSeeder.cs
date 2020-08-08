namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class ApplicationUsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Users.Any())
            {
                return;
            }

            var company = dbContext.Companies.FirstOrDefault();

            var applicationUsers = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Email = "example@example.com",
                    NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Company = company,
                    Education = "MIT",
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Age = 40,
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49,
                    Company = company,
                    FacebookAccountLink = "de",
                    TwitterAccountLink = "fr",
                    LinkedInAccountLink = "fe",
                    Education = "MIT",
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
            };

            foreach (var applicationUser in applicationUsers)
            {
                foreach (var category in dbContext.Categories)
                {
                    applicationUser.ApplicationUserCategories.Add(new ApplicationUserCategory
                    {
                        Category = category,
                    });
                }
            }

            await dbContext.Users.AddRangeAsync(applicationUsers);
        }
    }
}
