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
    [Route("api/equipments")]
    public class EquipmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEquipmentService _equipmentService;
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentController(IEquipmentService equipmentService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _equipmentService = equipmentService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<EquipmentViewModel>> GetEquipments()
        {
            var equipments = await _unitOfWork.EquipmentRepository.GetAll();
            
            var equipmentsResponse = _mapper.Map<IEnumerable<EquipmentViewModel>>(equipments);
            
            return Ok(equipmentsResponse);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EquipmentViewModel>> GetEquipment(Guid id)
        {
            var equipment = await _unitOfWork.EquipmentRepository.GetById(id);
            if (equipment is null) return NotFound();
            
            var equipmentResponse = _mapper.Map<EquipmentViewModel>(equipment);
            
            return Ok(equipmentResponse);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EquipmentViewModel equipmentViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var equipment = _mapper.Map<Equipment>(equipmentViewModel);

            var success = _equipmentService.Create(equipment);

            return Created($"{equipment.Id}", new {success});
        }
        
        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] EquipmentViewModel equipmentViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var equipment = await _unitOfWork.EquipmentRepository.Search(e => e.Id == id);
            if (equipment is null) return NotFound();

            var equipmentUpdated = _mapper.Map(equipmentViewModel, equipment);
            equipmentUpdated.Id = id;

            var success = _equipmentService.Update(equipmentUpdated);

            return Ok(new{ success });
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var equipment = await _unitOfWork.EquipmentRepository.Search(e => e.Id == id);
            if (equipment is null) return NotFound();
            
            var success = _equipmentService.Remove(equipment);
            
            return Accepted(new {success});
        }

    }
}