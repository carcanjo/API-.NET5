using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IVaccineRegistrationRepository : IBaseRepository<VaccineRegistration>
    {
        Task<VaccineRegistration> GetControlDose();
    }
}
