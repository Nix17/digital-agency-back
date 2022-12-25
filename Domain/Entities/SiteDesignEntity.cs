using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SiteDesignEntity : DictionaryEntity, IDictionaryEntity
{
    public SiteDesignEntity()
    {
    }

    public SiteDesignEntity(string name, string description, int price) : base(name, description, price)
    {
    }
}
