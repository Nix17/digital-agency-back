using Application.DTO.Common;
using Application.DTO.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Order;

public class OrderDTO : AuditableBaseDTO
{
    public OfferDTO Offer { get; set; }
    public KeyValueDTO User { get; set; }
    public double OrderCost { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Agreement { get; set; }
}
