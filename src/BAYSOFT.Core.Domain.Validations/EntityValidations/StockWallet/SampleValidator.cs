﻿using BAYSOFT.Core.Domain.Entities.StockWallet;
using FluentValidation;

namespace BAYSOFT.Core.Domain.Validations.EntityValidations.StockWallet
{
    public class SampleValidator : AbstractValidator<Sample>
    {
        public SampleValidator()
        {
            RuleFor(x => x.Description).NotNull().WithMessage("{0} cannot be null!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("{0} cannot be empty!");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("{0} must have at least 3 caracters!");
            RuleFor(x => x.Description).MaximumLength(100).WithMessage("{0} must have a maximum of 100 caracters!");
        }
    }
}
