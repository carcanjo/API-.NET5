using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("the entity cannot be empty")
                .NotNull()
                .WithMessage("the entity cannot be null");

            RuleFor(x => x.Name)
              .NotNull()
              .WithMessage("The patient name cannot be null")

              .NotEmpty()
              .WithMessage("The patient name cannot be empty")

              .MinimumLength(3)
              .WithMessage("The name must be at least 3 characters long")
              .MaximumLength(80)
              .WithMessage("The name must be up to 80 characters long");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("The email cannot be null")

                .NotEmpty()
                .WithMessage("The email cannot be null")

                .MinimumLength(10)
                .WithMessage("the email must be at least 10 characters long")

                .MaximumLength(180)
                .WithMessage("the email must be at most 180 characters long")

                .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                .WithMessage("The email is invalid");

            RuleFor(x => x.Cpf)
                .NotNull()
                .WithMessage("the cpf cannot be empty")
                .MaximumLength(11)
                .WithMessage("cpf can not have more than 11 characters")
                .MinimumLength(11)
                .WithMessage("cpf can not be less than 11 characters")
                .NotEmpty()
                .WithMessage("the cpf cannot be null");

            RuleFor(x => x.DateOfBirth)
                .NotNull()
                .WithMessage("Date if birth cannot be empty")
                .NotEmpty()
                .WithMessage("Date of birth cannot be empty");

            RuleFor(x => x.Status)
                .NotNull()
                .WithMessage("status cannot be null")
                .NotEmpty()
                .WithMessage("status cannot be empty");

            RuleFor(x => x.Address)
                .NotNull()
                .WithMessage("Adress can not be null")
                .NotEmpty()
                .WithMessage("Adress can not be empty");
        }
    }
}
