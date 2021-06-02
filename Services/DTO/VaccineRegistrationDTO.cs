using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class VaccineRegistrationDTO
    {
        public long Id { get; set; }
        public DateTime VaccinationDate { get; private set; }
        public Patient Patient { get; private set; }
        public Vaccine Vaccine { get; private set; }
        public DateTime FirtDose { get; private set; }
        public DateTime? SecondDose { get; private set; }

        public VaccineRegistrationDTO() { }

        public VaccineRegistrationDTO(long id, DateTime vaccinationDate, DateTime firtDose, DateTime? secondDose)
        {
            Id = id;
            VaccinationDate = vaccinationDate;
            FirtDose = firtDose;
            SecondDose = secondDose;
        }
    }
}
