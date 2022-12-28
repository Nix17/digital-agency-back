using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OrderEntity: AuditableBaseEntity
{
    public Guid OfferId { get; set; }
    public OfferEntity Offer { get; set; }

    public Guid UserId { get; set; }
    public UserEntity User { get; set; }

    public DateTime OrderDate { get; set; }

    public bool Agreement { get; set; }
}
