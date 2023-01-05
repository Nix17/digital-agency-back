using Application.Interfaces.Services;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Order;

public class OrderForm
{
    public Guid OfferId { get; set; }
    public Guid UserId { get; set; }
    public double OrderCost { get; set; }
    public DateTime OrderDate { get; set; }
    public bool Agreement { get; set; }
}

public class OrderFormUpd
{
    public double OrderCost { get; set; }
}

//public class OrderFormValidator: AbstractValidator<OrderForm>
//{
//    private readonly IUnitOfWork _uow;

//    public OrderFormValidator(IUnitOfWork uow)
//    {
//        _uow = uow;

//        RuleFor(p => p.OfferId)
//            .MustAsync(IsOfferExist)
//            .WithMessage("{PropertyName}: Error! offer doesn't exist");

//        RuleFor(p => p.UserId)
//            .MustAsync(IsUserExist)
//            .WithMessage("{PropertyName}: Error! User doesn't exist");
//    }

//    private async Task<bool> IsUserExist(Guid id, CancellationToken cancellationToken)
//    {
//        return await _uow.UserRepo.ExistsAsync(id);
//    }

//    private async Task<bool> IsOfferExist(Guid id, CancellationToken cancellationToken)
//    {
//        return await _uow.OfferRepo.ExistsAsync(id);
//    }
//}