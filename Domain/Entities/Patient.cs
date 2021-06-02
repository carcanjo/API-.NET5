using Core.Exceptions;
using Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Patient : Base
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public bool Status { get; private set; }

        [ForeignKey("Patient")]
        public int VaccineId { get; private set; }
        public ICollection<Vaccine> Vaccine { get; private set; }

        public Patient() { }

        public override bool Validate()
        {
            var validator = new PatientValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Some fields are invalid!", _errors);
            }
            return true;
        }
    }
}
