using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class VaccineRegistrationValidator : AbstractValidator<VaccineRegistration>
    {
        public VaccineRegistrationValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("This entity cannot be empty!")
                .NotNull()
                .WithMessage("This entity cannot be empty");

            RuleFor(x => x.VaccinationDate)
                .Empty()
                .WithMessage("This date of vaccination cannot be empty")
                .NotNull()
                .WithMessage("This date of vaccination cannot be empty");

            RuleFor(x => x.Patient)
                .NotEmpty()
                .WithMessage("This pattient cannot be empty");
        }
    }
}
