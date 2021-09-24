using Application.DTOs;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    public class HistoricoEstadoEquipamentoController : BaseApiController
    {
        private readonly IHistoricoEstadoEquipamentoService _historicoEstadoEquipamentoService;

        public HistoricoEstadoEquipamentoController(
            IHistoricoEstadoEquipamentoService historicoEstadoEquipamentoService)
        {
            _historicoEstadoEquipamentoService = historicoEstadoEquipamentoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _historicoEstadoEquipamentoService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _historicoEstadoEquipamentoService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(HistoricoEstadoEquipamentoDTO request)
        {
            return Ok(await _historicoEstadoEquipamentoService.RegisterAsync(request));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(HistoricoEstadoEquipamentoDTO request)
        {
            return Ok(await _historicoEstadoEquipamentoService.UpdateAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _historicoEstadoEquipamentoService.RemoveAsync(id));
        }
    }
}
