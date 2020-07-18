namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Blogs)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
