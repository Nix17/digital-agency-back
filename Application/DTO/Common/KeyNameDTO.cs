using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Common;

public interface IKeyName
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class KeyNameDTO : IKeyName
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public interface IKeyNameDescription: IKeyName
{
    public string Description { get; set; }
}

public interface IKeyNameDescPrice: IKeyNameDescription
{
    public int Price { get; set; }
}

public class KeyNameDescPriceDTO : AuditableIntIdDTO, IKeyNameDescPrice
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
}