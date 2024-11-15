﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions;

public class ValidationCustomException : Exception
{
    public ValidationCustomException() : base("ValidationException")
    {
        Errors = new List<string>();
    }
    public List<string> Errors { get; }
    public ValidationCustomException(IEnumerable<ValidationFailure> failures)
        : this()
    {
        foreach (var failure in failures)
        {
            Errors.Add(failure.ErrorMessage);
        }
    }

    public ValidationCustomException(IEnumerable<string> failures)
        : this()
    {
        foreach (var failure in failures.Distinct().ToList())
        {
            Errors.Add(failure);
        }
    }

}
