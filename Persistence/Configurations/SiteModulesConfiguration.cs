using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class SiteModulesConfiguration : IEntityTypeConfiguration<SiteModulesEntity>
{
    public void Configure(EntityTypeBuilder<SiteModulesEntity> builder)
    {
        builder.ToTable("site_modules").HasKey(m => m.Id);
        builder.ToTable("site_modules").HasIndex(m => m.Name);
        builder.Property(m => m.Name).HasDefaultValue("").IsRequired().HasMaxLength(500);
        builder.Property(m => m.Description).HasDefaultValue("").IsRequired().HasMaxLength(2000);
        builder.Property(m => m.Price).HasDefaultValue(0).IsRequired();
    }
}
