using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OptionalDesignEntity : DictionaryEntity, IDictionaryEntity
{
    public OptionalDesignEntity()
    {
    }

    public OptionalDesignEntity(string name, string description, int price) : base(name, description, price)
    {
    }
}
