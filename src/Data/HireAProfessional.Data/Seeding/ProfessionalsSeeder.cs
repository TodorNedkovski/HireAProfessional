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

    public class ProfessionalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Professionals.Any())
            {
                return;
            }

            var professionals = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Email = "example@example.com",
                    NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new ApplicationUser
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
            };

            var userManager = (UserManager<ApplicationUser>)serviceProvider.GetService(typeof(UserManager<ApplicationUser>));

            foreach (var professional in professionals)
            {
                await userManager.AddToRoleAsync(professional, "Professional");
            }

            await dbContext.AddRangeAsync(professionals);
        }
    }
}
