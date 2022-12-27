using Application.DTO.Common;
using Application.DTO.User;
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

namespace Application.Features.User.Queries;

public class GetUserByIdQuery: IRequest<Response<UserDTO>>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<UserDTO>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<UserDTO>> Handle(GetUserByIdQuery req, CancellationToken cancellationToken)
    {
        var obj = await _uow.UserRepo.FindAsync(o => o.Id == req.Id);
        var res = _mapper.Map<UserDTO>(obj);
        return new Response<UserDTO>(res);
    }
}

public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error Guid!");
    }
}