using AutoMapper;
using Core.Exceptions;
using Management.ViewModel;
using Management.ViewModel.RegistrationVaccineViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Interfaces;
using System;
using System.Threading.Tasks;
using VaccineManagement.Utilities;
using VaccineManagement.ViewModels;

namespace Management.Controllers
{
    [ApiController]
    public class VaccineRegistrationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVaccineRegistrationService _registrationService;

        public VaccineRegistrationController(IMapper mapper, IVaccineRegistrationService registrationService)
        {
            _mapper = mapper;
            _registrationService = registrationService;
        }

        [HttpPost]
        [Authorize]
        [Route("api/vi/registration/create")]
        public async Task<IActionResult> Create([FromBody] CreateRegistrationViewModel createRegistrationViewModel)
        {
            try
            {
                var createDTO = _mapper.Map<VaccineRegistrationDTO>(createRegistrationViewModel);
                var createRegistration = await _registrationService.Create(createDTO);
                return Ok(new ResultViewModel
                {
                    Message = "registration successfully created",
                    Success = true,
                    Data = createRegistrationViewModel
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

        [HttpPut]
        [Authorize]
        [Route("/api/vi/registration/update")]
        public async Task<IActionResult> Update([FromBody] UpdateRegistrationViewModel updateRegistrationViewModel)
        {
            try
            {
                var updateDTO = _mapper.Map<VaccineRegistrationDTO>(updateRegistrationViewModel);
                var updateRegistration = await _registrationService.Update(updateDTO);
                return Ok(new ResultViewModel
                {
                    Message = "registration successfully update",
                    Success = true,
                    Data = updateRegistrationViewModel
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
        [Route("/api/v1/registration/remove/{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            try
            {
                await _registrationService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "registration successfully delete",
                    Success = true,
                    Data = null
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

        [HttpGet]
        [Authorize]
        [Route("/api/v1/registration/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var registration = await _registrationService.Get(id);
                if (registration == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "no registration found",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "registration found successfully",
                    Success = true,
                    Data = registration
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

        [HttpGet]
        [Authorize]
        [Route("/api/v1/registration/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var registrationAll = await _registrationService.Get();
                if (registrationAll == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "no registration found",
                        Success = true,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "registration found successfully",
                    Success = true,
                    Data = registrationAll
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
    }
}
