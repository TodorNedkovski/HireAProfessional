﻿namespace HireAProfessional.Data.Configurations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> categoryEntity)
        {
            categoryEntity
                .HasKey(c => c.Id);

            categoryEntity
                .HasMany(c => c.ApplicationUserCategories)
                .WithOne(uc => uc.Category)
                .HasForeignKey(uc => uc.CategoryId);
        }
    }
}
