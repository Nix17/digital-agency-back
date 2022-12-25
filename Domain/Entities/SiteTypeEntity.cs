using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class SiteTypeEntity : DictionaryEntity, IDictionaryEntity
{
    public SiteTypeEntity()
    {
    }

    public SiteTypeEntity(string name, string description, int price, string iniName = "") : base(name, description, price)
    {
        Created = DateTime.Now;
        LastModified = DateTime.Now;
        CreatedBy = iniName;
        LastModifiedBy = iniName;
    }
}
