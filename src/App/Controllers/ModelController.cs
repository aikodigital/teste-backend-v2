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
    [Route("api/models")]
    public class ModelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IModelService _modelService;

        public ModelController(IMapper mapper, IUnitOfWork unitOfWork, IModelService modelService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _modelService = modelService;
        }
        
        [HttpGet]
        public async Task<ActionResult<ModelViewModel>> GetModels()
        {
            var models = await _unitOfWork.ModelRepository.GetAll();
            var modelsResponse = _mapper.Map<IEnumerable<ModelViewModel>>(models);
            return Ok(modelsResponse);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ModelViewModel>> GetById(Guid id)
        {
            var model = await _unitOfWork.ModelRepository.GetById(id);
            if (model is null) return NotFound();

            var modelResponse = _mapper.Map<ModelViewModel>(model);

            return Ok(modelResponse);
        }

        [HttpPost]
        public ActionResult Create([FromBody] ModelViewModel modelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();
            
            var model = _mapper.Map<Model>(modelViewModel);

            var success = _modelService.Create(model);
            
            return Created($"{model.Id}", new {success});
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] ModelViewModel modelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var model = await _unitOfWork.ModelRepository.Search(m => m.Id == id);
            if (model is null) return NotFound();

            var modelUpdated = _mapper.Map<Model>(modelViewModel);
            modelUpdated.Id = id;

            var success = _modelService.Update(modelUpdated);

            return Ok(new {success});
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var model = await _unitOfWork.ModelRepository.Search(m => m.Id == id);
            if (model is null) NotFound();

            var success = _modelService.Remove(model);

            return Accepted(new {success});
        }
    }
}