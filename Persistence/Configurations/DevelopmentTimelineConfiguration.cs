using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class DevelopmentTimelineConfiguration : IEntityTypeConfiguration<DevelopmentTimelineEntity>
{
    public void Configure(EntityTypeBuilder<DevelopmentTimelineEntity> builder)
    {
        builder.ToTable("development_timelines").HasKey(m => m.Id);
        builder.Property(m => m.Name).HasDefaultValue("").IsRequired().HasMaxLength(500);
        builder.Property(m => m.MultiplicationFactor).HasDefaultValue(0).IsRequired();
    }
}
