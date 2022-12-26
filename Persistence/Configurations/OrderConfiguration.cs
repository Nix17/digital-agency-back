using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("orders").HasKey(m => m.Id);
        builder.ToTable("orders").HasIndex(m => m.OfferId);
        builder.ToTable("orders").HasIndex(m => m.UserId);
        builder.Property(m => m.Agreement).HasDefaultValue(false).IsRequired();
    }
}
