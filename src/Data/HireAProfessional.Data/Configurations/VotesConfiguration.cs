namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class VotesConfiguration : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> voteBuilder)
        {
            voteBuilder
                .HasKey(v => v.Id);

            voteBuilder
                .HasOne(v => v.JobPost)
                .WithMany(j => j.Votes)
                .HasForeignKey(v => v.JobPostId);

            voteBuilder
                .HasOne(v => v.ApplicationUser)
                .WithMany(j => j.Votes)
                .HasForeignKey(v => v.ApplicationUserId);
        }
    }
}
