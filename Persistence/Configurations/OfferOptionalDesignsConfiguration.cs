using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class OfferOptionalDesignsConfiguration : IEntityTypeConfiguration<OfferOptionalDesignsEntity>
{
    public void Configure(EntityTypeBuilder<OfferOptionalDesignsEntity> builder)
    {
        builder.ToTable("offer_optional_designs").HasKey(m => m.Id);
        builder.ToTable("offer_optional_designs").HasIndex(m => m.OfferId);
        builder.ToTable("offer_optional_designs").HasIndex(m => m.OptionalDesignId);
    }
}
