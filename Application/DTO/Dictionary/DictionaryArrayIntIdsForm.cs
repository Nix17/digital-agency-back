using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Dictionary;

public class DictionaryArrayIntIdsForm
{
    public List<int> Ids { get; set; } = new List<int>();
    public DictionaryIdentificator DictIdentificators { get; set; }
}