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

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Web Design",
                    ImageUrl = "https://lebedev.agency/wp-content/uploads/2018/12/Web_Design.png",
                    Description = "Some text",
                },
                new Category
                {
                    Name = "Front End Developer",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/55047dd1e4b02d4e9aeb6b57/1426832738507-GQVXCU3WTTVNZ7LIFW73/ke17ZwdGBToddI8pDm48kEA-1ir-L1a-3goS75Bhw9l7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UZOrbj_nYcWtwdMdKNRfYP2xOBGuH2aHLdfD-ABQQVYiByJpHluJsqJoN79A0VawVw/image-asset.jpeg",
                    Description = "Some text",
                },
                new Category
                {
                    Name = "Back End Developer",
                    ImageUrl = "https://images.squarespace-cdn.com/content/v1/55047dd1e4b02d4e9aeb6b57/1426832719560-0XQAPNSC9S2ZBZLU03J2/ke17ZwdGBToddI8pDm48kEA-1ir-L1a-3goS75Bhw9l7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z5QPOohDIaIeljMHgDF5CVlOqpeNLcJ80NK65_fV7S1UZOrbj_nYcWtwdMdKNRfYP2xOBGuH2aHLdfD-ABQQVYiByJpHluJsqJoN79A0VawVw/image-asset.jpeg",
                    Description = "Some text",
                },
                new Category
                {
                    Name = "Lawyer",
                    ImageUrl = "https://www.elmens.com/wp-content/uploads/2019/10/Law.jpg",
                    Description = "Some text",
                },
                new Category
                {
                    Name = "Sales",
                    ImageUrl = "https://www.midataview.com/assets/images/main-feature.png",
                    Description = "Some text",
                },
                new Category
                {
                    Name = "Gardener",
                    ImageUrl = "https://dcassetcdn.com/design_img/3639605/767649/767649_20351797_3639605_3ca6a847_image.jpg",
                    Description = "Some text",
                },
            };

            await dbContext.Categories.AddRangeAsync(categories);
        }
    }
}
