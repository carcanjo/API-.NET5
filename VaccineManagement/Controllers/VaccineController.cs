using AutoMapper;
using Core.Exceptions;
using Management.ViewModel.VaccineViewModel;
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
    public class VaccineController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVaccineService _vaccineService;

        public VaccineController(IMapper mapper, IVaccineService vaccineService)
        {
            _mapper = mapper;
            _vaccineService = vaccineService;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/vaccine/create")]
        public async Task<IActionResult> Create([FromBody] CreateVaccineViewModel vaccineViewModel)
        {
            try
            {
                var vaccineDTO = _mapper.Map<VaccineDTO>(vaccineViewModel);
                var vaccineCreate = await _vaccineService.Create(vaccineDTO);
                return Ok(new ResultViewModel
                {
                    Message = "vaccine successfully created",
                    Success = true,
                    Data = vaccineViewModel
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
        [Route("/api/v1/vaccine/update")]
        public async Task<IActionResult> Update([FromBody] UpdateVaccineViewModel updateVaccine)
        {
            try
            {
                var vaccineDTO = _mapper.Map<VaccineDTO>(updateVaccine);
                var vaccineUpdate = await _vaccineService.Update(vaccineDTO);
                return Ok(new ResultViewModel
                {
                    Message = "vaccine successfully change",
                    Success = true,
                    Data = updateVaccine
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
        [Route("/api/v1/vaccine/remove/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _vaccineService.Remove(id);
                return Ok(new ResultViewModel
                {
                    Message = "vaccine successfully delete",
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
        [Route("/api/vi/vaccine/get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var vaccine = await _vaccineService.Get(id);
                if (vaccine == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "no vaccine found",
                        Success = false,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "vaccine found successfully",
                    Success = true,
                    Data = vaccine
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
        [Route("/api/vi/vaccine/get-all/")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vaccineAll = await _vaccineService.Get();
                if (vaccineAll == null)
                    return Ok(new ResultViewModel
                    {
                        Message = "no vaccine found",
                        Success = false,
                        Data = null
                    });

                return Ok(new ResultViewModel
                {
                    Message = "vaccine found successfully",
                    Success = true,
                    Data = vaccineAll
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
