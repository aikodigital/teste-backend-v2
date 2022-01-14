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
    [Route("api/states")]
    public class StateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStateService _stateService;
        private readonly IUnitOfWork _unitOfWork;

        public StateController(IMapper mapper, IStateService stateService, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _stateService = stateService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StateViewModel>>> GetStates()
        {
            var states = await _unitOfWork.StateRepository.GetAll();

            var statesResponse = _mapper.Map<IEnumerable<StateViewModel>>(states);

            return Ok(statesResponse);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<StateViewModel>> GetState(Guid id)
        {
            var state = await _unitOfWork.StateRepository.Search(s => s.Id == id);
            if (state is null) return NotFound();

            var stateResponse = _mapper.Map<StateViewModel>(state);

            return Ok(stateResponse);
        }

        [HttpPost]
        public ActionResult CreateState([FromBody] StateViewModel stateViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var state = _mapper.Map<State>(stateViewModel);

            var success = _stateService.Create(state);

            return Created($"{state.Id}", new {success});
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateState(Guid id, [FromBody] StateViewModel stateViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var state = await _unitOfWork.StateRepository.Search(s => s.Id == id);
            if (state is null) NotFound();

            var stateUpdated = _mapper.Map<State>(stateViewModel);
            stateUpdated.Id = id;

            var success = _stateService.Update(stateUpdated);

            return Ok(new {success});
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteState(Guid id)
        {
            var state = await _unitOfWork.StateRepository.Search(s => s.Id == id);
            if (state is null) return NotFound();

            var success = _stateService.Remove(state);

            return Accepted(new {success});
        }
    }
}