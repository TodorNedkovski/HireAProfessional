namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ApplicationUserCompany : IEntityTypeConfiguration<ApplicationUsersCompanies>
    {
        public void Configure(EntityTypeBuilder<ApplicationUsersCompanies> applicationUserCategoryBuilder)
        {
            applicationUserCategoryBuilder
                .HasKey(uc => new { uc.CompanyId, uc.ApplicationUserId });

            applicationUserCategoryBuilder
                .HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.ApplicationUsersCompanies)
                .HasForeignKey(uc => uc.CompanyId);

            applicationUserCategoryBuilder
                .HasOne(uc => uc.Company)
                .WithMany(c => c.ApplicationUsersCompanies)
                .HasForeignKey(uc => uc.CompanyId);
        }
    }
}
