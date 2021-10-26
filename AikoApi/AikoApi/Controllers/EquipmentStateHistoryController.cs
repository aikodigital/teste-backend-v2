using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AikoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EquipmentStateHistoryController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        protected DatabaseContext _context { get; }

        public EquipmentStateHistoryController(IRepositoryWrapper repository, IMapper mapper, DatabaseContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistoryDTO>>> Get()
        {
            try
            {
                var listResultModel = await _repository.EquipmentStateHistory.GetAll();
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("date/{date}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistoryDTO>>> GetByDate([FromRoute] DateTime date)
        {
            try
            {
                var listResultModel = await _repository.EquipmentStateHistory.GetByDate(date);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("equipment-id/{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistory>>> GetByEquipmentId([FromRoute] Guid id)
        {
            try
            {
                var listResultModel = await _repository.EquipmentStateHistory.GetByEquipmentId(id);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("equipment-state-id/{id}")]
        public async Task<ActionResult<IEnumerable<EquipmentStateHistoryDTO>>> GetByEquipmentStateId(
            [FromRoute] Guid id)
        {
            try
            {
                var listResultModel = await _repository.EquipmentStateHistory.GetByEquipmentStateId(id);
                var listResultModelDTO = _mapper.Map<IEnumerable<EquipmentStateHistoryDTO>>(listResultModel);
                return Ok(listResultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpGet("current-equipment-state/{equipmentId}")]
        public async Task<ActionResult<EquipmentStateDTO>> GetCurrentEquipmentState(Guid equipmentId)
        {
            try
            {
                var resultModel = await _repository.EquipmentStateHistory.GetCurrentEquipmentState(equipmentId);
                var resultModelDTO = _mapper.Map<EquipmentStateHistoryDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPost]
        public async Task<ActionResult<EquipmentStateHistoryDTO>> Post([FromBody] EquipmentStateHistoryDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentStateHistory>(modelDTO);
                model.Date = DateTime.Now;
                model.EquipmentId = new Guid("1c7e9615-cc1c-4d72-8496-190fe5791c8b");
                model.EquipmentStateId = new Guid("03b2d446-e3ba-4c82-8dc2-a5611fea6e1f");
                // var resultModel = await _repository.EquipmentStateHistory.Post(model);
                await _context.EquipmentStateHistories.AddAsync(model);
                await _context.SaveChangesAsync();
                await _context.Entry(model).ReloadAsync();
                // var resultModelDTO = _mapper.Map<EquipmentStateHistoryDTO>(resultModel);
                return Ok(model);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpPut]
        public async Task<ActionResult<EquipmentStateHistoryDTO>> Put([FromBody] EquipmentStateHistoryDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentStateHistory>(modelDTO);
                var resultModel = await _repository.EquipmentStateHistory.Put(model);
                var resultModelDTO = _mapper.Map<EquipmentStateHistoryDTO>(resultModel);
                return Ok(resultModelDTO);
            }
            catch (Exception e)
            {
                var sErrorMessage = $"{DateTime.Now} - {nameof(Get)} : {e.Message}";
                return StatusCode(500, sErrorMessage);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(EquipmentStateHistoryDTO modelDTO)
        {
            try
            {
                var model = _mapper.Map<EquipmentStateHistory>(modelDTO);
                var result = await _repository.EquipmentStateHistory.Remove(model);
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