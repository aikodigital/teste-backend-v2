using System;
using System.Collections;
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
    [Route("api/hourly-earnings")]
    public class ModelStateHourlyEarningsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IModelStateHourlyEarningService _modelStateHourlyEarningService;
        private readonly IUnitOfWork _unitOfWork;

        public ModelStateHourlyEarningsController(
            IMapper mapper, 
            IModelStateHourlyEarningService modelStateHourlyEarningService, 
            IUnitOfWork unitOfWork) {
            _mapper = mapper;
            _modelStateHourlyEarningService = modelStateHourlyEarningService;
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<ModelStateHourlyEarnings>>> GetEarningsByModel(Guid id)
        {
            var earningsByModel = await _unitOfWork.ModelStateHourlyEarningsRepository.GetEarningsByModel(id);
            var earningsByModelResponse = _mapper.Map<IEnumerable<ModelStateHourlyEarningViewModel>>(earningsByModel);
            return Ok(earningsByModelResponse);
        }

        [HttpPost]
        public ActionResult CreateHourlyEarningsRecord([FromBody] ModelStateHourlyEarningViewModel modelStateHourlyEarningViewModel)
        {
            if (!ModelState.IsValid) return NotFound();

            var hourlyEarnings = _mapper.Map<ModelStateHourlyEarnings>(modelStateHourlyEarningViewModel);

            var success = _modelStateHourlyEarningService.Create(hourlyEarnings);

            return Created($"{hourlyEarnings.ModelId}", new {success});
        }
        
        [HttpDelete("{id:guid}")]
        public ActionResult DeletePositionHistory(Guid id)
        {
            var success = _modelStateHourlyEarningService.DeleteHourlyEarningsByModel(id);

            return Accepted(new {success});
        }
    }
}