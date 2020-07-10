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

            var professionals = new List<ProfessionalUser>
            {
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        Email = "example@example.com",
                        NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
                        FirstName = "Bon",
                        LastName = "Jovi",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "2179e5ad-7556-4475-ba87-10f108519c8d",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Sarah",
                        LastName = "Hyland",
                        Age = 29,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "168ddb91-8b97-4c1c-8ed1-0f400c23819e",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Ty",
                        LastName = "Burrell",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "4b59442e-40c0-4841-a0be-fafe898d2c0d",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Nathan",
                        LastName = "Fillion",
                        Age = 49 ,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "8be949cc-b32c-4b78-a9d7-bf27426736ec",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Stana",
                        LastName = "Katic",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "9f46a0d2-7933-40e6-8ced-002f0d43e4b0",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Charlie",
                        LastName = "Sheen",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "b8f821fd-8cd4-41c5-a5a6-712f8d412930",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Jon",
                        LastName = "Cryer",
                        Age = 29,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "168ddb91-8b97-4c1c-8ed1-0f400c23819e",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Angus",
                        LastName = "Jones",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "2179e5ad-7556-4475-ba87-10f108519c8d",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Ashton",
                        LastName = "Kutcher",
                        Age = 49 ,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "4b59442e-40c0-4841-a0be-fafe898d2c0d",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "April",
                        LastName = "Bowlby",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "8be949cc-b32c-4b78-a9d7-bf27426736ec",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Bon",
                        LastName = "Jovi",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "9f46a0d2-7933-40e6-8ced-002f0d43e4b0",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser 
                    {
                        FirstName = "Sarah",
                        LastName = "Hyland",
                        Age = 29,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "b8f821fd-8cd4-41c5-a5a6-712f8d412930",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser 
                    {
                        FirstName = "Ty",
                        LastName = "Burrell",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "168ddb91-8b97-4c1c-8ed1-0f400c23819e",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Nathan",
                        LastName = "Fillion",
                        Age = 49 ,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "2179e5ad-7556-4475-ba87-10f108519c8d",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Stana",
                        LastName = "Katic",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "4b59442e-40c0-4841-a0be-fafe898d2c0d",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Charlie",
                        LastName = "Sheen",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "8be949cc-b32c-4b78-a9d7-bf27426736ec",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Jon",
                        LastName = "Cryer",
                        Age = 29,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "9f46a0d2-7933-40e6-8ced-002f0d43e4b0",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Angus",
                        LastName = "Jones",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "b8f821fd-8cd4-41c5-a5a6-712f8d412930",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "Ashton",
                        LastName = "Kutcher",
                        Age = 49 ,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "168ddb91-8b97-4c1c-8ed1-0f400c23819e",
                },
                new ProfessionalUser
                {
                    User = new ApplicationUser
                    {
                        FirstName = "April",
                        LastName = "Bowlby",
                        Age = 40,
                        ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                    },
                    CategoryId = "2179e5ad-7556-4475-ba87-10f108519c8d",
                },
            };

            var userManager = (UserManager<ApplicationUser>)serviceProvider.GetService(typeof(UserManager<ApplicationUser>));

            foreach (var professional in professionals)
            {
                await userManager.AddToRoleAsync(professional.User, "Professional");
            }

            await dbContext.AddRangeAsync(professionals);
        }
    }
}
