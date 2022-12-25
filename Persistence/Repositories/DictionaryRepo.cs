using Application.DTO.Dictionary;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Common;
using Domain.Data;
using Domain.Entities;
using Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;

public class DictionaryRepo : IDictionaryRepo
{
    protected readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public DictionaryRepo(ApplicationDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
    }

    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            this.disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<int> CreateNewRecordAsync(DictionaryForm data, DictionaryIdentificator dict)
    {
        int resId = 0;
        switch (dict)
        {
            case DictionaryIdentificator.SityType:
                var objST = _mapper.Map<SiteTypeEntity>(data);
                await _context.SiteTypes.AddAsync(objST);
                await _context.SaveChangesAsync();
                resId = objST.Id;
                break;

            case DictionaryIdentificator.SiteModules:
                var objSM = _mapper.Map<SiteModulesEntity>(data);
                await _context.SiteModules.AddAsync(objSM);
                await _context.SaveChangesAsync();
                resId = objSM.Id;
                break;

            case DictionaryIdentificator.SiteDesign:
                var objSD = _mapper.Map<SiteDesignEntity>(data);
                await _context.SiteDesigns.AddAsync(objSD);
                await _context.SaveChangesAsync();
                resId = objSD.Id;
                break;

            case DictionaryIdentificator.OptionalDesign:
                var objOD = _mapper.Map<OptionalDesignEntity>(data);
                await _context.OptionalDesigns.AddAsync(objOD);
                await _context.SaveChangesAsync();
                resId = objOD.Id;
                break;

            case DictionaryIdentificator.SiteSupport:
                var objSS = _mapper.Map<SiteSupportEntity>(data);
                await _context.SiteSupports.AddAsync(objSS);
                await _context.SaveChangesAsync();
                resId = objSS.Id;
                break;

            default:
                break;
        }
        return resId;
    }

    public async Task<bool> DeleteSelectRecordsAsync(List<int> data, DictionaryIdentificator dict)
    {
        switch (dict)
        {
            case DictionaryIdentificator.SityType:
                foreach (var id in data)
                {
                    var item = await _context.SiteTypes.FirstOrDefaultAsync(o => o.Id == id);
                    if (item != null)
                    {
                        _context.SiteTypes.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                break;

            case DictionaryIdentificator.SiteModules:
                foreach (var id in data)
                {
                    var item = await _context.SiteModules.FirstOrDefaultAsync(o => o.Id == id);
                    if (item != null)
                    {
                        _context.SiteModules.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                break;

            case DictionaryIdentificator.SiteDesign:
                foreach (var id in data)
                {
                    var item = await _context.SiteDesigns.FirstOrDefaultAsync(o => o.Id == id);
                    if (item != null)
                    {
                        _context.SiteDesigns.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                break;

            case DictionaryIdentificator.OptionalDesign:
                foreach (var id in data)
                {
                    var item = await _context.OptionalDesigns.FirstOrDefaultAsync(o => o.Id == id);
                    if (item != null)
                    {
                        _context.OptionalDesigns.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                break;

            case DictionaryIdentificator.SiteSupport:
                foreach (var id in data)
                {
                    var item = await _context.SiteSupports.FirstOrDefaultAsync(o => o.Id == id);
                    if (item != null)
                    {
                        _context.SiteSupports.Remove(item);
                        await _context.SaveChangesAsync();
                    }
                }
                break;

            default:
                return false;
        }

        return true;
    }

    public async Task<bool> ExistsAsync(int id, DictionaryIdentificator dict)
    {
        switch (dict)
        {
            case DictionaryIdentificator.SityType:
                return await _context.SiteTypes.FindAsync(id) != null;

            case DictionaryIdentificator.SiteModules:
                return await _context.SiteModules.FindAsync(id) != null;

            case DictionaryIdentificator.SiteDesign:
                return await _context.SiteDesigns.FindAsync(id) != null;

            case DictionaryIdentificator.OptionalDesign:
                return await _context.OptionalDesigns.FindAsync(id) != null;

            case DictionaryIdentificator.SiteSupport:
                return await _context.SiteSupports.FindAsync(id) != null;
        }
        return false;
    }

    public async Task<IReadOnlyList<IDictionaryEntity>> GetAllAsync(DictionaryIdentificator dict)
    {
        switch(dict)
        {
            case DictionaryIdentificator.SityType:
                var queryST = _context.SiteTypes.AsQueryable();
                return await queryST.AsNoTracking().ToListAsync();

            case DictionaryIdentificator.SiteModules:
                var querySM = _context.SiteModules.AsQueryable();
                return await querySM.AsNoTracking().ToListAsync();

            case DictionaryIdentificator.SiteDesign:
                var querySD = _context.SiteDesigns.AsQueryable();
                return await querySD.AsNoTracking().ToListAsync();

            case DictionaryIdentificator.OptionalDesign:
                var queryOD = _context.OptionalDesigns.AsQueryable();
                return await queryOD.AsNoTracking().ToListAsync();

            case DictionaryIdentificator.SiteSupport:
                var querySS = _context.SiteSupports.AsQueryable();
                return await querySS.AsNoTracking().ToListAsync();

            default:
                return null;
        }
    }

    public async Task<IDictionaryEntity> UpdateRecordAsync(int id, DictionaryForm data, DictionaryIdentificator dict)
    {
        IDictionaryEntity result = null;

        switch (dict)
        {
            case DictionaryIdentificator.SityType:
                var objST = await _context.SiteTypes.FirstOrDefaultAsync(o => o.Id == id);
                if (objST != null)
                {
                    _mapper.Map(data, objST);
                    await _context.SiteTypes.SingleUpdateAsync(objST);
                    await _context.SaveChangesAsync();
                    result = objST;
                }
                break;

            case DictionaryIdentificator.SiteModules:
                var objSM = await _context.SiteModules.FirstOrDefaultAsync(o => o.Id == id);
                if (objSM != null)
                {
                    _mapper.Map(data, objSM);
                    await _context.SiteModules.SingleUpdateAsync(objSM);
                    await _context.SaveChangesAsync();
                    result = objSM;
                }
                break;

            case DictionaryIdentificator.SiteDesign:
                var objSD = await _context.SiteDesigns.FirstOrDefaultAsync(o => o.Id == id);
                if (objSD != null)
                {
                    _mapper.Map(data, objSD);
                    await _context.SiteDesigns.SingleUpdateAsync(objSD);
                    await _context.SaveChangesAsync();
                    result = objSD;
                }
                break;

            case DictionaryIdentificator.OptionalDesign:
                var objOD = await _context.OptionalDesigns.FirstOrDefaultAsync(o => o.Id == id);
                if (objOD != null)
                {
                    _mapper.Map(data, objOD);
                    await _context.OptionalDesigns.SingleUpdateAsync(objOD);
                    await _context.SaveChangesAsync();
                    result = objOD;
                }
                break;

            case DictionaryIdentificator.SiteSupport:
                var objSS = await _context.SiteSupports.FirstOrDefaultAsync(o => o.Id == id);
                if (objSS != null)
                {
                    _mapper.Map(data, objSS);
                    await _context.SiteSupports.SingleUpdateAsync(objSS);
                    await _context.SaveChangesAsync();
                    result = objSS;
                }
                break;

            default:
                return result;
        }

        await _context.SaveChangesAsync();
        return result;
    }
}
