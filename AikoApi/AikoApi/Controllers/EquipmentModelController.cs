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
    public class EquipmentModelController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public EquipmentModelController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        } 
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentModelDTO>>> Get()
        {
            try
            {
                var equipmentModels = await _repository.EquipmentModel.GetAll();
                return Ok(equipmentModels);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipmentModelDTO>> GetById([FromRoute] Guid id)
        {
            try
            {
                var equipmentModel = await _repository.EquipmentModel.GetById(id);
                return Ok(equipmentModel);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<EquipmentModelDTO>> GetByName(string name)
        {
            try
            {
                var equipmentModels = await _repository.EquipmentModel.GetByName(name);
                var dto = _mapper.Map<List<EquipmentModelDTO>>(equipmentModels);
                return Ok(dto);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentModelDTO>> Post([FromBody] EquipmentModel model)
        {
            try
            {
                var equipmentModel = await _repository.EquipmentModel.Post(model);
                return Ok(equipmentModel);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentModelDTO>> Put([FromBody] EquipmentModel model)
        {
            try
            {
                var equipmentModel = await _repository.EquipmentModel.Put(model);
                return Ok(equipmentModel);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentModel model)
        {
            try
            {
                var result = await _repository.EquipmentModel.Remove(model);
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
