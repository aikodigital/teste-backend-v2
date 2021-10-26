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
                var listResultModel = await _repository.EquipmentModel.GetAll();
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentModelDTO>>(listResultModel);
                return Ok(listResultModelDTO);
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
                var model = await _repository.EquipmentModel.GetById(id);
                var resultModelDTO = _mapper.Map<EquipmentModelDTO>(model);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult<EquipmentModelDTO>> GetByName([FromRoute] string name)
        {
            try
            {
                var listResultModel = await _repository.EquipmentModel.GetByName(name);
                var listResultModelDTO = _mapper.Map<List<EquipmentModelDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentModelDTO>> Post([FromBody] EquipmentModelDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentModel>(modelDTO);
                var resultModel = await _repository.EquipmentModel.Post(model);
                var resultModelDTO = _mapper.Map<EquipmentModelDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentModelDTO>> Put([FromBody] EquipmentModelDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentModel>(modelDTO);
                var resultModel = await _repository.EquipmentModel.Put(model);
                var resultModelDTO = _mapper.Map<EquipmentModelDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentModelDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentModel>(modelDTO);
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
