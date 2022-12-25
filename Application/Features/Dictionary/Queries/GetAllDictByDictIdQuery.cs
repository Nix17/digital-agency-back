using Application.DTO.Common;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Data;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dictionary.Queries;

public class GetAllDictByDictIdQuery: IRequest<Response<List<KeyNameDescPriceDTO>>>
{
    public GetAllDictByDictIdQuery(DictionaryIdentificator dictionary)
    {
        Dictionary = dictionary;
    }

    public DictionaryIdentificator Dictionary { get; }
}

public class GetAllDictByDictIdQueryHandler : IRequestHandler<GetAllDictByDictIdQuery, Response<List<KeyNameDescPriceDTO>>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public GetAllDictByDictIdQueryHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<List<KeyNameDescPriceDTO>>> Handle(GetAllDictByDictIdQuery req, CancellationToken cancellationToken)
    {
        var items = await _uow.DictRepo.GetAllAsync(req.Dictionary);
        var res = _mapper.Map<List<KeyNameDescPriceDTO>>(items.OrderBy(o => o.Id));
        return new Response<List<KeyNameDescPriceDTO>>(res);
    }
}

public class GetAllDictByDictIdQueryValidator: AbstractValidator<GetAllDictByDictIdQuery>
{}