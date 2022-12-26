using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class OfferConfiguration : IEntityTypeConfiguration<OfferEntity>
{
    public void Configure(EntityTypeBuilder<OfferEntity> builder)
    {
        builder.ToTable("offers").HasKey(m => m.Id);
        builder.ToTable("offers").HasIndex(m => m.OfferNumber).IsUnique();
        builder.ToTable("offers").HasIndex(m => m.UserId);
        builder.ToTable("offers").HasIndex(m => m.SiteTypeId);
        builder.ToTable("offers").HasIndex(m => m.SiteDesignId);
        builder.Property(m => m.Comment).HasDefaultValue("").IsRequired().HasMaxLength(1000);
    }
}
