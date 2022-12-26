using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class OfferModulesConfiguration : IEntityTypeConfiguration<OfferModulesEntity>
{
    public void Configure(EntityTypeBuilder<OfferModulesEntity> builder)
    {
        builder.ToTable("offer_modules").HasKey(m => m.Id);
        builder.ToTable("offer_modules").HasIndex(m => m.OfferId);
        builder.ToTable("offer_modules").HasIndex(m => m.SiteModulesId);
    }
}
