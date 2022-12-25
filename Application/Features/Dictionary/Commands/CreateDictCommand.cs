using Application.DTO.Dictionary;
using Application.Interfaces.Services;
using Application.Wrappers;
using AutoMapper;
using Domain.Common;
using Domain.Data;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Dictionary.Commands;

public class CreateDictCommand: IRequest<Response<int>>
{
    public CreateDictCommand(DictionaryIdentificator dictionary, DictionaryForm data)
    {
        Dictionary = dictionary;
        Data = data;
    }

    public DictionaryIdentificator Dictionary { get; }
    public DictionaryForm Data { get; }
}

public class CreateDictCommandHandler : IRequestHandler<CreateDictCommand, Response<int>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public CreateDictCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateDictCommand cmd, CancellationToken cancellationToken)
    {
        var obj = _mapper.Map<DictionaryEntity>(cmd.Data);
        await _uow.DictRepo.CreateNewRecordAsync(obj, cmd.Dictionary);
        return new Response<int>(obj.Id);
    }
}

public class CreateDictCommandValidator: AbstractValidator<CreateDictCommand>
{
    private readonly IUnitOfWork _uow;

    public CreateDictCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p.Dictionary)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!!");

        RuleFor(p => p.Data)
            .NotNull()
            .WithMessage("{PropertyName}: error!!");
    }
}