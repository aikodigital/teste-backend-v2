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
    public class EquipmentStateController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EquipmentStateController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentStateDTO>>> Get()
        {
            try
            {
                var listResultModel = await _repository.EquipmentState.GetAll();
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentStateDTO>> GetById([FromRoute] Guid id)
        {
            try
            {
                var resultModel = await _repository.EquipmentState.GetById(id);
                var resultModelDTO = _mapper.Map<EquipmentStateDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateDTO>>> GetByName([FromRoute] string name)
        {
            try
            {
                var listResultModel = await _repository.EquipmentState.GetByName(name);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("color/{color}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateDTO>>> GetByColor([FromRoute] string color)
        {
            try
            {
                var listResultModel = await _repository.EquipmentState.GetByColor(color);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentStateDTO>> Post([FromBody] EquipmentStateDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentState>(modelDTO);
                var resultModel = await _repository.EquipmentState.Post(model);
                var resultModelDTO = _mapper.Map<EquipmentStateDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentStateDTO>> Put([FromBody] EquipmentStateDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentState>(modelDTO);
                var resultModel = await _repository.EquipmentState.Put(model);
                var resultModelDTO = _mapper.Map<EquipmentStateDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentStateDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentState>(modelDTO);
                var result = await _repository.EquipmentState.Remove(model);
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