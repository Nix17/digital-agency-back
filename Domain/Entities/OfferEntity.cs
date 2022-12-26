using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OfferEntity: AuditableBaseEntity
{
    public int OfferNumber { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    public double Cost { get; set; }

    public int SiteTypeId { get; set; }
    public SiteTypeEntity SiteType { get; set; }

    public int SiteDesignId { get; set; }
    public SiteDesignEntity SiteDesign { get; set; }

    public DateTime OrderDate { get; set; }

    public string Comment { get; set; }
}
