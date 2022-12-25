using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class OptionalDesignConfiguration : IEntityTypeConfiguration<OptionalDesignEntity>
{
    public void Configure(EntityTypeBuilder<OptionalDesignEntity> builder)
    {
        builder.ToTable("optional_designs").HasKey(m => m.Id);
        builder.ToTable("optional_designs").HasIndex(m => m.Name);
        builder.Property(m => m.Name).HasDefaultValue("").IsRequired().HasMaxLength(500);
        builder.Property(m => m.Description).HasDefaultValue("").IsRequired().HasMaxLength(2000);
        builder.Property(m => m.Price).HasDefaultValue(0).IsRequired();
    }
}
