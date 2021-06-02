using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class VaccineValidator : AbstractValidator<Vaccine>
    {
        public VaccineValidator()
        {
            RuleFor(x => x)
            .NotEmpty()
            .WithMessage("the entity cannot be empty")
            .NotNull()
            .WithMessage("the entity cannot be null");

            RuleFor(x => x.Manufacture)
                .NotEmpty()
                .WithMessage("the manufacturer can not be empty")
                .NotNull()
                .WithMessage("the manufacturer can not be null");

            RuleFor(x => x.Lot)
                .NotEmpty()
                .WithMessage("the lot can not be empty")
                .NotNull()
                .WithMessage("the lot can not be null");

            RuleFor(x => x.NumberOfDoses)
                .NotEmpty()
                .WithMessage("the number of doses can not be empty")
                .NotNull()
                .WithMessage("the number of doses can not be null");
            
            RuleFor(x => x.IntervalBetweenDoses)
                .NotEmpty()
                .WithMessage("the interval beteween doses can not be empty")
                .NotNull()
                .WithMessage("the interval beteween doses can not be null");

            RuleFor(x => x.DateValidity)
                .NotEmpty()
                .WithMessage("The date of validity can not be empty")
                .NotNull()
                .WithMessage("The date of validity can not be empty");



        }
    }
}
