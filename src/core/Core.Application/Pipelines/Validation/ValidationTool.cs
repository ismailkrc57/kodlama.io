﻿using FluentValidation;

namespace Core.Application.Pipelines.Validation;

public class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        ValidationContext<object> context = new(entity);
        var result = validator.Validate(context);
        if (!result.IsValid) throw new ValidationException(result.Errors);
    }
}