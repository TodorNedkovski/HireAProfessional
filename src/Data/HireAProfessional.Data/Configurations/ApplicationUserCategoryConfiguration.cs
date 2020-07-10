namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserCategoryConfiguration : IEntityTypeConfiguration<ApplicationUserCategory>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserCategory> builder)
        {
            builder
                .HasKey(uc => new { uc.CategoryId, uc.ApplicationUserId });

            builder
                .HasOne(uc => uc.Category)
                .WithMany(c => c.ApplicationUserCategories)
                .HasForeignKey(uc => uc.CategoryId);

            builder
                .HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.ApplicationUserCategories)
                .HasForeignKey(uc => uc.ApplicationUserId);
        }
    }
}
