using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using App.ViewModels;

using AutoMapper;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App.Pages
{
    public class StateHistoryModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public List<StateHistoryViewModel> StateHistories { get; set; }
        public StateHistoryViewModel LastState { get; set; }

        public StateHistoryModel(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task OnGetAsync([FromQuery] Guid id)
        {
            var stateHistories = await _unitOfWork.StateHistoryRepository.GetStateHistory(id);
            var currentState = stateHistories.LastOrDefault();
            LastState = _mapper.Map<StateHistoryViewModel>(currentState);
            StateHistories = _mapper.Map<List<StateHistoryViewModel>>(stateHistories);
        }
    }
}