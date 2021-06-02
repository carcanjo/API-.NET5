using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IPatientService
    {
        Task<PatientDTO> Create(PatientDTO userDTO);
        Task<PatientDTO> Update(PatientDTO userDTO);
        Task Remove(long id);
        Task<PatientDTO> Get(long id);
        Task<List<PatientDTO>> Get();
        Task<PatientDTO> GetByCpf(string cpf);
        Task<PatientDTO> GetByEmail(string email);
    }
}
