using Application.DTO.Common;
using Application.DTO.User;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Queries;

public class GetAllUsersQuery : IRequest<Response<List<UserDTO>>>
{
    public GetAllUsersQuery()
    {
    }
}

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQuery, Response<List<UserDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<UserDTO>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var items = await _uow.UserRepo.GetAllAsync();
        var res = _mapper.Map<List<UserDTO>>(items).ToList();
        return new Response<List<UserDTO>>(res);
    }
}
