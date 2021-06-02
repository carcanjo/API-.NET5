using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public class VaccineDTO
    {
        public long Id { get; set; }
        public string Manufacture { get; set; }
        public string Lot { get; set; }
        public DateTime DateValidity { get; set; }
        public int NumberOfDoses { get; set; }
        public DateTime IntervalBetweenDoses { get; set; }
        public ICollection<Patient> Patients { get; set; }


        public VaccineDTO() { }

        public VaccineDTO(long id, string manufacture, string lot, DateTime dateValidity, int numberOfDoses, DateTime intervalBetweenDoses, ICollection<Patient> patients)
        {
            Id = id;
            Manufacture = manufacture;
            Lot = lot;
            DateValidity = dateValidity;
            NumberOfDoses = numberOfDoses;
            IntervalBetweenDoses = intervalBetweenDoses;
            Patients = patients;
        }
    }
}
