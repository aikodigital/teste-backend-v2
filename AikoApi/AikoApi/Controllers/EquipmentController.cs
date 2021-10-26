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
    public class EquipmentController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public EquipmentController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> Get()
        {
            try
            {
                var listResultModel = await _repository.Equipment.GetAll();
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentDTO>> GetById([FromRoute] Guid id)
        {
            try
            {
                var resultModel = await _repository.Equipment.GetById(id);
                var resultModelDTO = _mapper.Map<EquipmentDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetByName([FromRoute] string name)
        {
            try
            {
                var listResultModel = await _repository.Equipment.GetByName(name);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-model/{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetByEquipmentModelId([FromRoute] Guid id)
        {
            try
            {
                var listResultModel = await _repository.Equipment.GetByEquipmentModelId(id);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<EquipmentDTO>> Post([FromBody] EquipmentDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<Equipment>(modelDTO);
                var resultModel = await _repository.Equipment.Post(model);
                var resultModelDTO = _mapper.Map<EquipmentDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentDTO>> Put([FromBody] EquipmentDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<Equipment>(modelDTO);
                var resultModel = await _repository.Equipment.Put(model);
                var resultModelDTO = _mapper.Map<EquipmentDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<Equipment>(modelDTO);
                var result = await _repository.Equipment.Remove(model);
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
