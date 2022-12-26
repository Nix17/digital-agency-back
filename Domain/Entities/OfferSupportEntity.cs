using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OfferSupportEntity: BaseEntity
{
    public Guid OfferId { get; set; }
    public OfferEntity Offer { get; set; }

    public int SiteSupportId { get; set; }
    public SiteSupportEntity SiteSupport { get; set; }
}
