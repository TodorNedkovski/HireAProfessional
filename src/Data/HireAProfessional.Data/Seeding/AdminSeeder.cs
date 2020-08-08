namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (await dbContext.Users.AnyAsync(u => u.NormalizedEmail == "TNEDKOVSKI12@GMAIL.COM"))
            {
                return;
            }

            var company = await dbContext.Companies.FirstOrDefaultAsync();
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.NormalizedName == "ADMINISTRATOR");

            var admin = new ApplicationUser
            {
                FirstName = "Todor",
                LastName = "Nedkovski",
                Age = 17,
                Email = "TNEDKOVSKI12@GMAIL.COM",
                ImageUrl = "",
                NormalizedUserName = "TNEDKOVSKI12@GMAIL.COM",
                NormalizedEmail = "TNEDKOVSKI12@GMAIL.COM",
                LinkedInAccountLink = "",
                PasswordHash = "AQAAAAEAACcQAAAAED92rnttOPambs0wKCI/6pDh2e9DamtD5gmMDx3mfGvxZB2REEgwmPFbrJjVGIz0Zw==",
                Company = company,
                Education = "Softuni",
                UserName = "tnedkovski12@gmail.com",
                TwitterAccountLink = "https://twitter.com/nedkovski",
                FacebookAccountLink = "https://www.facebook.com/profile.php?id=100008991873514&ref=bookmarks",
            };

            await dbContext.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                UserId = admin.Id,
                RoleId = role.Id,
            });

            await dbContext.Users.AddAsync(admin);
            await dbContext.SaveChangesAsync();
        }
    }
}
