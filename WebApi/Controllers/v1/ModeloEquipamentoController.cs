using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class ModeloEquipamentoController : BaseApiController
    {
        private readonly IModeloEquipamentoService _modeloEquipamentoService;

        public ModeloEquipamentoController(IModeloEquipamentoService modeloEquipamentoService)
        {
            _modeloEquipamentoService = modeloEquipamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _modeloEquipamentoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _modeloEquipamentoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(ModelEquipamentoDTO request)
        {
            return Ok(await _modeloEquipamentoService.RegisterAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ModelEquipamentoDTO request)
        {
            return Ok(await _modeloEquipamentoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _modeloEquipamentoService.RemoveAsync(id));
        }
    }
}
