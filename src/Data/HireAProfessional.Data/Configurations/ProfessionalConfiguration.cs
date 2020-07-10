namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProfessionalConfiguration : IEntityTypeConfiguration<ProfessionalUser>
    {
        public void Configure(EntityTypeBuilder<ProfessionalUser> builder)
        {
            builder
                .HasKey(p => new { p.Id });

            builder
                .HasOne(pu => pu.User)
                .WithOne(u => u.ProfessionalUser);

            builder
                .HasOne(pu => pu.Category)
                .WithMany(u => u.ProfessionalUsers);
        }
    }
}
