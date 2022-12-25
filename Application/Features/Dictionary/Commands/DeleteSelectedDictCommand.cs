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

namespace Application.Features.Dictionary.Commands;

public class DeleteSelectedDictCommand : IRequest<Response<string>>
{
    public DeleteSelectedDictCommand(DictionaryIdentificator dictionary, List<int> ids)
    {
        Dictionary = dictionary;
        Ids = ids;
    }

    public DictionaryIdentificator Dictionary { get; }
    public List<int> Ids { get; }
}

public class DeleteSelectedDictCommandHandler : IRequestHandler<DeleteSelectedDictCommand, Response<string>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public DeleteSelectedDictCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<string>> Handle(DeleteSelectedDictCommand cmd, CancellationToken cancellationToken)
    {
        await _uow.DictRepo.DeleteSelectRecordsAsync(cmd.Ids, cmd.Dictionary);
        var msg = $"Deleted: {cmd.Ids.Count} of {cmd.Ids}";
        return new Response<string>(msg);
    }
}

public class DeleteSelectedDictCommandValidator: AbstractValidator<DeleteSelectedDictCommand>
{
    private readonly IUnitOfWork _uow;

    public DeleteSelectedDictCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error!");
    }

    private async Task<bool> IsExist(DeleteSelectedDictCommand cmd, CancellationToken cancellationToken)
    {
        foreach(var id in cmd.Ids)
        {
            if (!_uow.DictRepo.ExistsAsync(id, cmd.Dictionary)) return false;
        }
        return true;
    }
}