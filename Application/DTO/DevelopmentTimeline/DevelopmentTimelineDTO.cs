using Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.DevelopmentTimeline;

public class DevelopmentTimelineDTO: AuditableIntIdDTO
{
    public string Name { get; set; }
    public double MultiplicationFactor { get; set; }
}
