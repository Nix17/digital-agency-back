using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class OfferSupportConfiguration : IEntityTypeConfiguration<OfferSupportEntity>
{
    public void Configure(EntityTypeBuilder<OfferSupportEntity> builder)
    {
        builder.ToTable("offer_supports").HasKey(m => m.Id);
        builder.ToTable("offer_supports").HasIndex(m => m.OfferId);
        builder.ToTable("offer_supports").HasIndex(m => m.SiteSupportId);
    }
}
