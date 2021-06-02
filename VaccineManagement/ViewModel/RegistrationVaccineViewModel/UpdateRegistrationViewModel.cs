using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.ViewModel.RegistrationVaccineViewModel
{
    public class UpdateRegistrationViewModel
    {
        public int Id { get; set; }
        public DateTime VaccinationDate { get;  set; }
        public Patient Patient { get;  set; }
        public Vaccine Vaccine { get;  set; }
        public DateTime FirtDose { get;  set; }
        public DateTime? SecondDose { get;  set; }
    }
}
