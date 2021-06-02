using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IVaccineRegistrationService
    {
        Task<VaccineRegistrationDTO> Create(VaccineRegistrationDTO vaccineDTO);
        Task<VaccineRegistrationDTO> Update(VaccineRegistrationDTO vaccineDTO);
        Task Remove(long id);
        Task<VaccineRegistrationDTO> Get(long id);
        Task<List<VaccineRegistrationDTO>> Get();
    }
}
