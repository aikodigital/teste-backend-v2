using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class EstadoEquipamentoController : BaseApiController
    {
        private readonly IEstadoEquipamentoService _estadoEquipamentoService;

        public EstadoEquipamentoController(IEstadoEquipamentoService estadoEquipamentoService)
        {
            _estadoEquipamentoService = estadoEquipamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _estadoEquipamentoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _estadoEquipamentoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(EstadoEquipamentoDTO request)
        {
            return Ok(await _estadoEquipamentoService.RegisterAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(EstadoEquipamentoDTO request)
        {
            return Ok(await _estadoEquipamentoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _estadoEquipamentoService.RemoveAsync(id));
        }
    }
}
