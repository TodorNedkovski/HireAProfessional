namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore.Internal;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Count() > 0)
            {
                return;
            }

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Web Design",
                ImageUrl = "https://www.webdesignskills.us/wp-content/uploads/2019/04/what-does-a-web-designer-do.jpeg",
                Description = "Some text",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Front End Developer",
                ImageUrl = "https://miro.medium.com/max/2560/1*PcKrfD2t06m1b33lW_SUwg.jpeg",
                Description = "Some text",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Back End Developer",
                ImageUrl = "https://miro.medium.com/max/785/1*6X5dVgCGuU-9W66SmAiosA.jpeg",
                Description = "Some text",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Lawyer",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTjLysLubMZ9_DRUjDxMmezCXljms_QtZLp3A&usqp=CAU",
                Description = "Some text",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Sales",
                ImageUrl = "https://heygom.com/wp-content/uploads/2018/10/5-sales-tips-for-those-who-do-not-like-selling.jpg",
                Description = "Some text",
            });

            await dbContext.Categories.AddAsync(new Category
            {
                Name = "Gardener",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcS4aNtZ4Nxr4pojujAc99LmQfjPJMxXEwXHiw&usqp=CAU",
                Description = "Some text",
            });
        }
    }
}
