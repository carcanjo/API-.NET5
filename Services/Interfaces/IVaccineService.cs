using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IVaccineService
    {
        Task<VaccineDTO> Create(VaccineDTO vaccineDTO);
        Task<VaccineDTO> Update(VaccineDTO vaccineDTO);
        Task Remove(long id);
        Task<VaccineDTO> Get(long id);
        Task<List<VaccineDTO>> Get();
    }
}
