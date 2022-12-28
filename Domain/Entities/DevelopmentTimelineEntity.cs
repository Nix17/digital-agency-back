using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class DevelopmentTimelineEntity: AuditableIntIdEntity, IAuditableEntity
{
    public DevelopmentTimelineEntity()
    {
    }

    public DevelopmentTimelineEntity(string name, double multiplicationFactor)
    {
        Name = name;
        MultiplicationFactor = multiplicationFactor;
    }

    public string Name { get; set; }
    public double MultiplicationFactor { get; set; }
}
