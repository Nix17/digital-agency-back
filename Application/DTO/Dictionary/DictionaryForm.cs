using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Dictionary;

public class DictionaryForm
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; } = 0;
}

public class DictionaryFormBalidator : AbstractValidator<DictionaryForm>
{
    public DictionaryFormBalidator()
    {
        RuleFor(p => p.Name)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName}: Error!");

        RuleFor(p => p.Description)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName}: Error!");

        RuleFor(p => p.Price)
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName}: Error!");
    }
}