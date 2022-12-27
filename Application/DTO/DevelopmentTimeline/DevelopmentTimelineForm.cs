using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.DevelopmentTimeline;

public class DevelopmentTimelineForm
{
    public string Name { get; set; }
    public double MultiplicationFactor { get; set; }
}

public class DevelopmentTimelineFormValidator : AbstractValidator<DevelopmentTimelineForm>
{
    public DevelopmentTimelineFormValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName}: error!");

        RuleFor(p => p.MultiplicationFactor)
            .NotEqual(0)
            .WithMessage("{PropertyName}: error!");
    }
}