namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserReportConfiguration : IEntityTypeConfiguration<UserReport>
    {
        public void Configure(EntityTypeBuilder<UserReport> builder)
        {
            builder
                .HasKey(ur => ur.Id);

            builder
                .HasOne(ur => ur.Reporter)
                .WithMany(au => au.UserReports)
                .HasForeignKey(ur => ur.ReporterId);

            builder
                .HasOne(ur => ur.ReportedUser)
                .WithMany(au => au.ReportedByUsers)
                .HasForeignKey(ur => ur.ReportedUserId);
        }
    }
}
