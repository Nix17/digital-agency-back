using Application.DTO.Common;
using Application.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Offer;

public class OfferForm
{
    public int OfferNumber { get; set; }
    public Guid UserId { get; set; }
    public double Cost { get; set; }
    public int DevelopmentTimelineId { get; set; }
    public int SiteTypeId { get; set; }
    public int SiteDesignId { get; set; }
    public DateTime OrderDate { get; set; }
    public string Comment { get; set; }

    public List<int> SiteModulesIds { get; set; }
    public List<int> OptionalDesignIds { get; set; }
    public List<int> SiteSupportIds { get; set; }
}

public class OfferFormValidator: AbstractValidator<OfferForm>
{
    private readonly IUnitOfWork _uow;

    public OfferFormValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.OfferNumber).MustAsync(IsNumUnique).WithMessage("{PropertyName}: error! OfferNumber not unique!");
        
        RuleFor(p => p.UserId).MustAsync(IsUserExist).WithMessage("{PropertyName}: error! UserId doesn't exist!");
        
        RuleFor(p => p.DevelopmentTimelineId).MustAsync(IsDevTimeExist).WithMessage("{PropertyName}: error! DevelopmentTimelineId doesn't exist!");
        
        RuleFor(p => p.SiteDesignId).MustAsync(IsSiteDesignExist).WithMessage("{PropertyName}: error! SiteDesignId doesn't exist!");
        
        RuleFor(p => p.SiteModulesIds).MustAsync(IsSiteModulesIdsExist).WithMessage("{PropertyName}: error! SiteModulesIds doesn't exist!");
        
        RuleFor(p => p.OptionalDesignIds).MustAsync(IsOptionalDesignIdsExist).WithMessage("{PropertyName}: error! OptionalDesignIds doesn't exist!");
        
        RuleFor(p => p.SiteSupportIds).MustAsync(IsSiteSupportIdsExist).WithMessage("{PropertyName}: error! SiteSupportIds doesn't exist!");
        
        RuleFor(p => p.SiteTypeId).MustAsync(IsSiteTypeExist).WithMessage("{PropertyName}: error! SiteTypeId doesn't exist!");
    }

    private async Task<bool> IsNumUnique(int num, CancellationToken cancellationToken)
    {
        if ((await _uow.OfferRepo.FindAsync(o => o.OfferNumber == num)) != null) return false;
        return true;
    }

    private async Task<bool> IsUserExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }

    private async Task<bool> IsDevTimeExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.DevelopmentTimelineRepo.ExistsAsync(id);
    }

    private async Task<bool> IsSiteTypeExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.SiteTypeRepo.ExistsAsync(id);
    }

    private async Task<bool> IsSiteDesignExist(int id, CancellationToken cancellationToken)
    {
        return await _uow.SiteDesignRepo.ExistsAsync(id);
    }

    private async Task<bool> IsSiteModulesIdsExist(List<int> ids, CancellationToken cancellationToken)
    {
        foreach(var id in ids)
        {
            if (!(await _uow.SiteModulesRepo.ExistsAsync(id))) return false;
        }
        return true;
    }

    private async Task<bool> IsOptionalDesignIdsExist(List<int> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.OptionalDesignRepo.ExistsAsync(id))) return false;
        }
        return true;
    }

    private async Task<bool> IsSiteSupportIdsExist(List<int> ids, CancellationToken cancellationToken)
    {
        foreach (var id in ids)
        {
            if (!(await _uow.SiteSupportRepo.ExistsAsync(id))) return false;
        }
        return true;
    }
}