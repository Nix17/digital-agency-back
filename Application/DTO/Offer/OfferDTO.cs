using Application.DTO.Common;
using Application.DTO.DevelopmentTimeline;
using Application.DTO.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Offer;

public class OfferDTO : AuditableBaseDTO
{
    public int OfferNumber { get; set; }
    public KeyValueDTO User { get; set; }
    public double Cost { get; set; }
    public DevelopmentTimelineDTO DevelopmentTimeline { get; set; }
    public KeyNameDescPriceDTO SiteType { get; set; }
    public KeyNameDescPriceDTO SiteDesign { get; set; }
    public List<KeyNameDescPriceDTO> SiteModules { get; set; }
    public List<KeyNameDescPriceDTO> OptionalDesign { get; set; }
    public List<KeyNameDescPriceDTO> SitySupport { get; set; }
    public DateTime OrderDate { get; set; }
    public string Comment { get; set; }
}
