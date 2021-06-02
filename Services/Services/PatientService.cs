using AutoMapper;
using Core.Exceptions;
using Services.DTO;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientService(IMapper mapper, IPatientRepository userRepository)
        {
            _mapper = mapper;
            _patientRepository = userRepository;
        }

        public async Task<PatientDTO> Create(PatientDTO userDTO)
        {
            //Aqui vem a regra de negócio
            var userExists = await _patientRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException("Já existe um usuário cadastrado");

            var user = _mapper.Map<Patient>(userDTO);
            user.Validate();

            var userCreated = await _patientRepository.Create(user);

            return _mapper.Map<PatientDTO>(userCreated);
        }

        public async Task<PatientDTO> Get(long id)
        {
            var users = await _patientRepository.Get(id);

            return _mapper.Map<PatientDTO>(users);
        }

        public async Task<List<PatientDTO>> Get()
        {
            var allUsers = await _patientRepository.Get();

            return _mapper.Map<List<PatientDTO>>(allUsers);
        }

        public async Task<PatientDTO> GetByCpf(string cpf)
        {
            var users = await _patientRepository.GetByCpf(cpf);

            return _mapper.Map<PatientDTO>(users);
        }

        public async Task<PatientDTO> GetByEmail(string email)
        {
            var users = await _patientRepository.GetByEmail(email);

            return _mapper.Map<PatientDTO>(users);
        }

        public async Task Remove(long id)
        {
            await _patientRepository.Remove(id);
        }

        public async Task<PatientDTO> Update(PatientDTO userDTO)
        {
            //Aqui vem a regra de negócio
            var userExists = await _patientRepository.Get(userDTO.Id);

            if (userExists == null)
                throw new DomainException($"Não existe usuario com o id: {userDTO.Id}");

            var user = _mapper.Map<Patient>(userDTO);
            user.Validate();

            var userUpadate = await _patientRepository.Update(user);

            return _mapper.Map<PatientDTO>(userUpadate);
        }
    }
}
