namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;

    public class ProfessionalsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Professionals.Any())
            {
                return;
            }

            var professionals = new List<Professional>
            {
                new Professional
                {
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },

                new Professional
                {
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },

                new Professional
                {
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },

                new Professional
                {
                    FirstName = "Bon",
                    LastName = "Jovi",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Sarah",
                    LastName = "Hyland",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ty",
                    LastName = "Burrell",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Nathan",
                    LastName = "Fillion",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Stana",
                    LastName = "Katic",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Charlie",
                    LastName = "Sheen",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Jon",
                    LastName = "Cryer",
                    Age = 29,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Gardener"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Angus",
                    LastName = "Jones",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Sales"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "Ashton",
                    LastName = "Kutcher",
                    Age = 49 ,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
                new Professional
                {
                    FirstName = "April",
                    LastName = "Bowlby",
                    Age = 40,
                    Category = dbContext.Categories.FirstOrDefault(c => c.Name == "Back End Developer"),
                    ImageUrl = "https://www.bav.bg/static/img/kartof.6e6aba2.jpg",
                },
            };

            await dbContext.AddRangeAsync(professionals);
        }
    }
}
