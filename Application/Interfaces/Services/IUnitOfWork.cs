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

    IDevelopmentTimelineRepo DevelopmentTimelineRepo { get; }

    IUserRepo UserRepo { get; }

    IOfferRepo OfferRepo { get; }
    IOfferModuleRepo OfferModuleRepo { get; }
    IOfferOptionalDesignsRepo OfferOptionalDesignsRepo { get; }
    IOfferSupportRepo OfferSupportRepo { get; }
    IOrderRepo OrderRepo { get; }


    Task<bool> SaveChangesAsync();
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
