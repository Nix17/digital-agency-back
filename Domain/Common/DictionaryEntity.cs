using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common;

public interface IDictionaryEntity : IAuditableEntity, IAuditableIntIdEntity
{
    string Name { get; set; }
    string Description { get; set; }
    int Price { get; set; }
}

public class DictionaryEntity : AuditableIntIdEntity, IDictionaryEntity
{
    public DictionaryEntity()
    {
    }

    public DictionaryEntity(string name, string description, int price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
}
