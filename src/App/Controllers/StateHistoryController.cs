using System;
using System.Collections.Generic;
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
    [Route("api/state-history")]
    public class StateHistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStateHistoryService _stateHistoryService;

        public StateHistoryController(IMapper mapper, IUnitOfWork unitOfWork, IStateHistoryService stateHistoryService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _stateHistoryService = stateHistoryService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<StateHistoryViewModel>>> GetStateHistory(Guid id)
        {
            var stateHistory = await _unitOfWork.StateHistoryRepository.GetStateHistory(id);
            var stateHistoryResponse = _mapper.Map<IEnumerable<StateHistoryViewModel>>(stateHistory);
            return Ok(stateHistoryResponse);
        }
        
        [HttpGet("{id:guid}/current")]
        public async Task<ActionResult<StateHistoryViewModel>> GetCurrentState(Guid id)
        {
            var currentState = await _unitOfWork.StateHistoryRepository.GetCurrentState(id);
            var currentStateResponse = _mapper.Map<StateHistoryViewModel>(currentState);
            return Ok(currentStateResponse);
        }

        [HttpPost]
        public ActionResult CreateStateHistory([FromBody] StateHistoryViewModel stateHistoryViewModel)
        {
            if (!ModelState.IsValid) return NotFound();

            var stateHistory = _mapper.Map<StateHistory>(stateHistoryViewModel);

            var success = _stateHistoryService.Create(stateHistory);

            return Created($"{stateHistory.EquipmentId}", new {success});
        }
        
        [HttpDelete("{id:guid}")]
        public ActionResult DeleteStateHistory(Guid id)
        {
            var success = _stateHistoryService.DeleteStateHistory(id);

            return Accepted(new {success});
        }
    }
}