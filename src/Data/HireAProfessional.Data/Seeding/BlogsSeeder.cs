namespace HireAProfessional.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;

    public class BlogsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Blogs.Any())
            {
                return;
            }

            const string content = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ac leo quis nibh placerat interdum. In efficitur tortor eu ultrices consequat. Vestibulum fermentum elit id leo congue posuere. Cras nec elit eu sapien venenatis tristique. Vivamus nec urna fringilla, tristique tellus quis, congue turpis. Cras at tellus eu est egestas rutrum. Sed aliquet sit amet orci id volutpat. Aliquam et tincidunt elit. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aenean sit amet nibh sit amet massa tincidunt bibendum. Donec congue sapien in semper bibendum. Curabitur nec elit vitae lacus pellentesque rhoncus eu ut lectus. Integer fringilla quam sit amet arcu lacinia lobortis. Mauris accumsan sagittis hendrerit. Donec pulvinar fringilla risus, ac luctus justo volutpat sed.

Integer sodales sagittis lectus vel lobortis. Maecenas in lectus sed nulla facilisis posuere in a turpis. Pellentesque mi arcu, suscipit quis ipsum eget, pretium lacinia ex. Quisque malesuada, est nec rhoncus scelerisque, tortor dui congue magna, auctor pulvinar quam diam eget arcu. Donec enim ipsum, facilisis a nisi eu, cursus auctor urna. Mauris tempor aliquam ex id efficitur. Pellentesque id elementum tortor, vel rhoncus est. Nunc sed risus a neque tempor porttitor. Nam feugiat maximus nunc, pulvinar dictum erat convallis eu. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla facilisi.";

            var author = dbContext.Users.FirstOrDefault();

            var blogs = new List<Blog>
            {
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
                new Blog
                {
                    Author = author,
                    Content = content,
                    Title = "Very meaningful title",
                },
            };

            await dbContext.Blogs.AddRangeAsync(blogs);
        }
    }
}
