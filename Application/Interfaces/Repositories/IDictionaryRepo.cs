using Application.DTO.Dictionary;
using Domain.Common;
using Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories;

public interface IDictionaryRepo
{
    void Dispose();

    Task<IReadOnlyList<IDictionaryEntity>> GetAllAsync(DictionaryIdentificator dict);

    Task<IDictionaryEntity> CreateNewRecordAsync(IDictionaryEntity data, DictionaryIdentificator dict);

    Task<IDictionaryEntity> UpdateRecordAsync(int id, DictionaryForm data, DictionaryIdentificator dict);

    Task<bool> DeleteSelectRecordsAsync(List<int> data, DictionaryIdentificator dict);

    Task<bool> ExistsAsync(int id, DictionaryIdentificator dict);

    //Task<bool> ExistsListAsync(List<int> ids, DictionaryIdentificator dict);
}
