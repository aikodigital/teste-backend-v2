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
    public class EquipmentPositionHistoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        
        public EquipmentPositionHistoryController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistoryDTO>>> Get()
        {
            try
            {
                var listResultModel = await _repository.EquipmentPositionHistory.GetAll();
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentPositionHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("equipment-id/{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistoryDTO>>> GetByEquipmentId([FromRoute] Guid id)
        {
            try
            {
                var listResultModel = await _repository.EquipmentPositionHistory.GetByEquipmentId(id);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentPositionHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("position")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistoryDTO>>> GetByPosition([FromQuery] string lat, string lon)
        {
            try
            {
                var listResultModel = await _repository.EquipmentPositionHistory.GetByPosition(new Position
                {
                    lat = float.Parse(lat),
                    lon = float.Parse(lon)
                });
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentPositionHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistoryDTO>>> GetByDate([FromRoute] DateTime date)
        {
            try
            {
                var listResultModel = await _repository.EquipmentPositionHistory.GetByDate(date);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentPositionHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("current-equipment-position/{equipmentId}")]
        public async Task<ActionResult<EquipmentStateDTO>> GetCurrentEquipmentPosition(Guid equipmentId)
        {
            try
            {
                var resultModel = await _repository.EquipmentPositionHistory.GetCurrentEquipmentPosition(equipmentId);
                var resultModelDTO = _mapper.Map<EquipmentPositionHistoryDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("latitude/{latitude}")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistoryDTO>>> GetByLatitude([FromRoute] float latitude)
        {
            try
            {
                var listResultModel = await _repository.EquipmentPositionHistory.GetByLatitude(latitude);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentPositionHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpGet("longitude/{longitude}")]
        public async Task<ActionResult<IEnumerable<EquipmentPositionHistoryDTO>>> GetByLongitude([FromRoute] float longitude)
        {
            try
            {
                var listResultModel = await _repository.EquipmentPositionHistory.GetByLongitude(longitude);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentPositionHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<EquipmentPositionHistoryDTO>> Post([FromBody] EquipmentPositionHistoryDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentPositionHistory>(modelDTO);
                var resultModel = await _repository.EquipmentPositionHistory.Post(model);
                var resultModelDTO = _mapper.Map<EquipmentPositionHistoryDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpPut]
        public async Task<ActionResult<EquipmentPositionHistoryDTO>> Put([FromBody] EquipmentPositionHistoryDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentPositionHistory>(modelDTO);
                var resultModel = await _repository.EquipmentPositionHistory.Put(model);
                var resultModelDTO = _mapper.Map<EquipmentPositionHistoryDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}"; 
                return StatusCode(500, sErrorMessage);
            }
        }
        
        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] EquipmentPositionHistoryDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentPositionHistory>(modelDTO);
                var result = await _repository.EquipmentPositionHistory.Remove(model);
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