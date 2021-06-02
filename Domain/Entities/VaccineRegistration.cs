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
    public class VaccineRegistration : Base
    {
        public DateTime VaccinationDate { get; private set; }
        public DateTime FirtDose { get; private set; }
        public DateTime? SecondDose { get; private set; }


        [ForeignKey("Patient")]
        public long PatientId { get; set; }
        public Patient Patient { get; private set; }

        [ForeignKey("Vaccine")]
        public long VaccineId { get; private set; }
        public Vaccine Vaccine { get; private set; }



        public override bool Validate()
        {
            var validator = new VaccineRegistrationValidator();
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
