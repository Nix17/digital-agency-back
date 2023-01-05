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

public class UpdateOrderCostCommand : IRequest<Response<MessageResponse>>
{
    public UpdateOrderCostCommand(Guid id, OrderFormUpd data)
    {
        Id = id;
        Data = data;
    }

    public Guid Id { get; set; }
    public OrderFormUpd Data { get; set; }
}

public class UpdateOrderCostCommandHandler : IRequestHandler<UpdateOrderCostCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateOrderCostCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(UpdateOrderCostCommand cmd, CancellationToken cancellationToken)
    {
        var obj = await _uow.OrderRepo.FindAsync(o => o.Id == cmd.Id);
        obj.OrderCost = cmd.Data.OrderCost;
        await _uow.OrderRepo.UpdateAsync(obj);
        var msg = $"Order with id = { obj.Id } was successful update!";
        return new Response<MessageResponse>(msg);
    }
}

public class UpdateOrderCostCommandValidator : AbstractValidator<UpdateOrderCostCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderCostCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! Order doesn't exist!");

    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OrderRepo.ExistsAsync(id);
    }
}