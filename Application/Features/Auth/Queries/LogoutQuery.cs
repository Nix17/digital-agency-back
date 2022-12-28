using Application.Interfaces.Services;
using Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Queries;

public class LogoutQuery : IRequest<Response<bool>>
{
    public LogoutQuery()
    {
    }
}

public class LogoutQueryHandler : IRequestHandler<LogoutQuery, Response<bool>>
{
    private readonly IUnitOfWork _uow;

    public LogoutQueryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Response<bool>> Handle(LogoutQuery request, CancellationToken cancellationToken)
    {
        var temt = await _uow.UserRepo.CountAsync();
        return new Response<bool>(true);
    }
}
