using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common;

public interface IDictionaryEntity : IAuditableEntity, IAuditableIntIdEntity
{
    string Name { get; set; }
    bool IsActive { get; set; }
}

public class DictionaryEntity : AuditableIntIdEntity, IDictionaryEntity
{
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
