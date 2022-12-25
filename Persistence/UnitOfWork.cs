using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private IDictionaryRepo _dictRepo;
    private ISiteTypeRepo _siteTypeRepo;
    private ISiteModulesRepo _siteModulesRepo;
    private ISiteDesignRepo _siteDesignRepo;
    private IOptionalDesignRepo _optionalDesignRepo;
    private ISiteSupportRepo _siteSupportRepo;

    public UnitOfWork(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IDictionaryRepo DictRepo => _dictRepo = _dictRepo ?? new DictionaryRepo(_context, _mapper);
    public ISiteTypeRepo SiteTypeRepo => _siteTypeRepo = _siteTypeRepo ?? new SiteTypeRepo(_context);
    public ISiteModulesRepo SiteModulesRepo => _siteModulesRepo = _siteModulesRepo ?? new SiteModulesRepo(_context);
    public ISiteDesignRepo SiteDesignRepo => _siteDesignRepo = _siteDesignRepo ?? new SiteDesignRepo(_context);
    public IOptionalDesignRepo OptionalDesignRepo => _optionalDesignRepo = _optionalDesignRepo ?? new OptionalDesignRepo(_context);
    public ISiteSupportRepo SiteSupportRepo => _siteSupportRepo = _siteSupportRepo ?? new SiteSupportRepo(_context);


    public async Task<bool> SaveChangesAsync() { return (await _context.SaveChangesAsync()) > 0; }

    public async Task BeginAsync() { await _context.BeginTranAsync(); }

    public async Task CommitAsync() { await _context.CommitTranAsync(); }

    public async Task RollbackAsync() { await _context.RollbackTranAsync(); }

    public void Dispose() { _context.Dispose(); }
}
