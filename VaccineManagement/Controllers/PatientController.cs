using AutoMapper;
using Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Services;
using System;
using System.Threading.Tasks;
using VaccineManagement.Utilities;
using VaccineManagement.ViewModels;

namespace VaccineManagement.Controllers
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientService _userService;

        public PatientController(IMapper mapper, IPatientService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/patient/create")]
        public async Task<IActionResult> Create([FromBody] CreatePatientViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<PatientDTO>(userViewModel);
                var userCreate = await _userService.Create(userDTO);
                return Ok(new ResultViewModel
                {
                    Message = "user successfully created",
                    Success = true,
                    Data = userCreate
                });
            }
            catch (DomainException ex)
            {
                //erro de validação da aplicação
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                // dois tipo de erro um erro interno no servidor
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("/api/v1/patient/update")]
        public async Task<IActionResult> Update([FromBody] UpdatePatientViewModel userViewModel)
        {
            try
            {
                var userDTO = _mapper.Map<PatientDTO>(userViewModel);
                var userUpdate = await _userService.Update(userDTO);
                return Ok(new ResultViewModel
                {
                    Message = "Usuario atualizado com sucesso",
                    Success = true,
                    Data = userUpdate
                });

            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Erros));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("/api/v1/patient/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _userService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "Usuario removido com sucesso",
                    Success = true,
                    Data = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/patient/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await _userService.Get(id);

                if (user == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "Nenhum usuário foi encontrado com o id informado",
                        Success = false,
                        Data = user
                    });

                return Ok(new ResultViewModel
                {
                    Message = "Usuário encontrado com sucesso",
                    Success = true,
                    Data = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/patient/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUser = await _userService.Get();

                return Ok(new ResultViewModel
                {
                    Message = "patient successfully found",
                    Success = true,
                    Data = allUser
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.AplicationErrorMessage());
            }
        }

    }
}
