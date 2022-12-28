using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OfferOptionalDesignsEntity: BaseEntity
{
    public OfferOptionalDesignsEntity(Guid offerId, int optionalDesignId)
    {
        OfferId = offerId;
        OptionalDesignId = optionalDesignId;
    }

    public Guid OfferId { get; set; }
    public OfferEntity Offer { get; set; }

    public int OptionalDesignId { get; set; }
    public OptionalDesignEntity OptionalDesign { get; set; }
}
