using AutoMapper;
using Core.Exceptions;
using Domain.Entities;
using Infra.Interfaces;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VaccineRegistrationService : IVaccineRegistrationService
    {
        private readonly IMapper _mapper;
        private readonly IVaccineRegistrationRepository _vaccineRegistrationRepository;

        public async Task<VaccineRegistrationDTO> Create(VaccineRegistrationDTO vaccineDTO)
        {
            var vaccineRegistration = _mapper.Map<VaccineRegistration>(vaccineDTO);

            var registrationCreated = await _vaccineRegistrationRepository.Create(vaccineRegistration);

            return _mapper.Map<VaccineRegistrationDTO>(registrationCreated);
        }

        public async Task<VaccineRegistrationDTO> Get(long id)
        {
            var registration = await _vaccineRegistrationRepository.Get(id);

            return _mapper.Map<VaccineRegistrationDTO>(registration);
        }

        public async Task<List<VaccineRegistrationDTO>> Get()
        {
            var registrationAll = await _vaccineRegistrationRepository.Get();

            return _mapper.Map<List<VaccineRegistrationDTO>>(registrationAll);
        }

        public async Task Remove(long id)
        {
            await _vaccineRegistrationRepository.Remove(id);
        }

        public async Task<VaccineRegistrationDTO> Update(VaccineRegistrationDTO vaccineDTO)
        {
            var registrationExists = await _vaccineRegistrationRepository.Get(vaccineDTO.Id);

            if (registrationExists != null)
                throw new DomainException($"Não existe registro com o id: {vaccineDTO.Id}");

            var registration = _mapper.Map<VaccineRegistration>(vaccineDTO);
            registration.Validate();

            var registrationUpdate = await _vaccineRegistrationRepository.Update(registration);

            return _mapper.Map<VaccineRegistrationDTO>(registrationUpdate);
        }
    }
}
