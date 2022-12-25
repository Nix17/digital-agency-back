using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SiteModulesEntity : DictionaryEntity, IDictionaryEntity
{
    public SiteModulesEntity()
    {
    }

    public SiteModulesEntity(string name, string description, int price) : base(name, description, price)
    {
    }
}
