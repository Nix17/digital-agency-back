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

public class UpdateDictCommand: IRequest<Response<MessageResponse>>
{
    public UpdateDictCommand(DictionaryIdentificator dictionary, int id, DictionaryForm data)
    {
        Dictionary = dictionary;
        Id = id;
        Data = data;
    }

    public DictionaryIdentificator Dictionary { get; }
    public int Id { get; }
    public DictionaryForm Data { get; }
}

public class UpdateDictCommandHandler : IRequestHandler<UpdateDictCommand, Response<MessageResponse>>
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public UpdateDictCommandHandler(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<Response<MessageResponse>> Handle(UpdateDictCommand cmd, CancellationToken cancellationToken)
    {
        var res = await _uow.DictRepo.UpdateRecordAsync(cmd.Id, cmd.Data, cmd.Dictionary);
        var msg = $"Item with id = {res.Id} was updated!";
        return new Response<MessageResponse>(new MessageResponse(msg));
    }
}

public class UpdateDictCommandValidator: AbstractValidator<UpdateDictCommand>
{
    private readonly IUnitOfWork _uow;

    public UpdateDictCommandValidator(IUnitOfWork uow)
    {
        _uow = uow;

        RuleFor(p => p)
            .MustAsync(IsExist)
            .WithMessage("{PropertyName}: Error! Dict isn't exist!");
    }

    private async Task<bool> IsExist(UpdateDictCommand cmd, CancellationToken cancellationToken)
    {
        return await _uow.DictRepo.ExistsAsync(cmd.Id, cmd.Dictionary);
    }
}