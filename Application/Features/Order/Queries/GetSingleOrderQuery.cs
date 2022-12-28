using Application.DTO.Order;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Application.Features.Order.Queries;

public class GetSingleOrderQuery: IRequest<Response<OrderDTO>>
{
    public GetSingleOrderQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetSingleOrderQueryHandler : IRequestHandler<GetSingleOrderQuery, Response<OrderDTO>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetSingleOrderQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<OrderDTO>> Handle(GetSingleOrderQuery req, CancellationToken cancellationToken)
    {
        var obj = await _uow.OrderRepo.FindAsync(o => o.Id == req.Id);
        var res = _mapper.Map<OrderDTO>(obj);
        return new Response<OrderDTO>(res);
    }
}

public class GetSingleOrderQueryValidator: AbstractValidator<GetSingleOrderQuery>
{
    private readonly IUnitOfWork _uow;

    public GetSingleOrderQueryValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Id)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! Order doesn't exist");
    }

    private async Task<bool> IsExist(Guid id, CancellationToken cancellationToken)
    {
        return await _uow.OrderRepo.ExistsAsync(id);
    }
}