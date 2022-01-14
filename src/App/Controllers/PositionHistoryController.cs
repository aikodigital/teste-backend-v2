using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.ViewModels;

using AutoMapper;

using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [ApiController]
    [Route("api/position-history")]
    public class PositionHistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPositionHistoryService _positionHistoryService;
        private readonly IUnitOfWork _unitOfWork;

        public PositionHistoryController(IMapper mapper, IPositionHistoryService positionHistoryService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _positionHistoryService = positionHistoryService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<PositionHistoryViewModel>>> GetPositionHistory(Guid id)
        {
            var positionHistories = await _unitOfWork.PositionHistoryRepository.GetPositionHistory(id);

            var positionHistoryResponse = _mapper.Map<IEnumerable<PositionHistoryViewModel>>(positionHistories);

            return Ok(positionHistoryResponse);
        }
        
        [HttpGet("{id:guid}/current")]
        public async Task<ActionResult<PositionHistoryViewModel>> GetCurrentPosition(Guid id)
        {
            var currentPosition = await _unitOfWork.PositionHistoryRepository.GetCurrentPosition(id);

            var currentPositionResponse = _mapper.Map<PositionHistoryViewModel>(currentPosition);

            return Ok(currentPositionResponse);
        }

        [HttpPost]
        public ActionResult CreatePosition([FromBody] PositionHistoryViewModel positionHistoryViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var position = _mapper.Map<PositionHistory>(positionHistoryViewModel);

            var success = _positionHistoryService.Create(position);

            return Created($"{position.EquipmentId}", new {success});
        }

        [HttpDelete("{id:guid}")]
        public ActionResult DeletePositionHistory(Guid id)
        {
            var success = _positionHistoryService.DeletePositionHistory(id);

            return Accepted(new {success});
        }
    }
}