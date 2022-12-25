using Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services;
public interface IUnitOfWork
{
    IDictionaryRepo DictRepo { get; }
    ISiteTypeRepo SiteTypeRepo { get; }
    ISiteModulesRepo SiteModulesRepo { get; }
    ISiteDesignRepo SiteDesignRepo { get; }
    IOptionalDesignRepo OptionalDesignRepo { get; }
    ISiteSupportRepo SiteSupportRepo { get; }

    Task<bool> SaveChangesAsync();
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
