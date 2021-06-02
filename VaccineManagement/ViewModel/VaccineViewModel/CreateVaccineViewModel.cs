using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Management.ViewModel.VaccineViewModel
{
    public class CreateVaccineViewModel
    {
        public string Manufacture { get; set; }
        public string Lot { get; set; }
        public DateTime DateValidity { get; set; }
        public int NumberOfDoses { get; set; }
        public DateTime IntervalBetweenDoses { get; set; }
        public ICollection<Patient> Patients { get; set; }

    }
}
