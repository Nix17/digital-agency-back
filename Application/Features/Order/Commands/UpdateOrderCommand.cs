using Application.DTO.Order;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Order.Commands;

public class UpdateOrderCommand: IRequest<Response<MessageResponse>>
{
    public UpdateOrderCommand(Guid id, OrderForm data)
    {
        Id = id;
        Data = data;
    }

    public Guid Id { get; set; }
    public OrderForm Data { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(UpdateOrderCommand cmd, CancellationToken cancellationToken)
    {
        var obj = await _uow.OrderRepo.FindAsync(o => o.Id == cmd.Id);
        _mapper.Map(cmd.Data, obj);
        await _uow.OrderRepo.UpdateAsync(obj);
        var msg = $"Order with id = { obj.Id } was successful update!";
        return new Response<MessageResponse>(msg);
    }
}

public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! Order doesn't exist!");

        RuleFor(p => p.Data.OfferId)
            .MustAsync(IsOfferExist)
            .WithMessage("{PropertyName}: Error! offer doesn't exist");

        RuleFor(p => p.Data.UserId)
            .MustAsync(IsUserExist)
            .WithMessage("{PropertyName}: Error! User doesn't exist");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OrderRepo.ExistsAsync(id);
    }

    private async Task<bool> IsUserExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.UserRepo.ExistsAsync(id);
    }

    private async Task<bool> IsOfferExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OfferRepo.ExistsAsync(id);
    }
}