using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AikoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EquipmentModelStateHourlyEarningsController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EquipmentModelStateHourlyEarningsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModelStateHourlyEarningsDTO>>> Get()
        {
            try
            {
                var listResultModel = await _repository.EquipmentModelStateHourlyEarnings.GetAll();
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentModelStateHourlyEarningsDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("value/{value}")]
        public async Task<ActionResult<EquipmentModelStateHourlyEarningsDTO>> GetById([FromRoute] float value)
        {
            try
            {
                var resultModel = await _repository.EquipmentModelStateHourlyEarnings.GetByValue(value);
                var resultModelDTO = _mapper.Map<EquipmentModelStateHourlyEarningsDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-model-id/{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentModelStateHourlyEarningsDTO>>> GetByName([FromRoute] Guid id)
        {
            try
            {
                var listResultModel = await _repository.EquipmentModelStateHourlyEarnings.GetByEquipmentModelId(id);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentModelStateHourlyEarningsDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("equipment-state-id/{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentModelStateHourlyEarningsDTO>>> GetByColor([FromRoute] Guid id)
        {
            try
            {
                var listResultModel = await _repository.EquipmentModelStateHourlyEarnings.GetByEquipmentStateId(id);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentModelStateHourlyEarningsDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<EquipmentModelStateHourlyEarningsDTO>> Post([FromBody] EquipmentModelStateHourlyEarningsDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentModelStateHourlyEarnings>(modelDTO);
                var stateobj = _repository.EquipmentState.GetById(model.EquipmentStateId).Result;
                var modelobj = _repository.EquipmentModel.GetById(model.EquipmentModelId).Result;
                model.EquipmentModel = modelobj;
                model.EquipmentState = stateobj;
                var resultModel = await _repository.EquipmentModelStateHourlyEarnings.Post(model);
                var resultModelDTO = _mapper.Map<EquipmentModelStateHourlyEarningsDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentModelStateHourlyEarningsDTO>> Put([FromBody] EquipmentModelStateHourlyEarningsDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentModelStateHourlyEarnings>(modelDTO);
                var resultModel = await _repository.EquipmentModelStateHourlyEarnings.Put(model);
                var resultModelDTO = _mapper.Map<EquipmentModelStateHourlyEarningsDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentModelStateHourlyEarningsDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentModelStateHourlyEarnings>(modelDTO);
                var result = await _repository.EquipmentModelStateHourlyEarnings.Remove(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
    }
}