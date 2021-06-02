using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VaccineService : IVaccineService
    {
        public Task<VaccineDTO> Create(VaccineDTO vaccineDTO)
        {
            //vai a regra de negócio
            throw new NotImplementedException();
        }

        public Task<VaccineDTO> Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VaccineDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public Task<VaccineDTO> Update(VaccineDTO vaccineDTO)
        {
            throw new NotImplementedException();
        }
    }
}
