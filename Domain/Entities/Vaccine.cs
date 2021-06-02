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
    public class Vaccine : Base
    {
        public string Manufacture { get; private set; }
        public string Lot { get; private set; }
        public DateTime DateValidity { get; private set; }
        public int NumberOfDoses { get; private set; }
        public DateTime IntervalBetweenDoses { get; private set; }

        [ForeignKey("Patient")]
        public int PatienteId { get; private set; }
        public ICollection<Patient> Patients { get; private set; }

        public Vaccine() { }

        public override bool Validate()
        {
            var validator = new VaccineValidator();
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
